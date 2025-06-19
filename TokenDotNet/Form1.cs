using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using IntegrationHub;
using static System.Collections.Specialized.BitVector32;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace TokenDotNet
{
    /// <summary>
    /// MainForm: The primary UI form for the TokenDotNet application.
    /// 
    /// Overview:
    /// This application serves as a client interface for integrating with POS (Point of Sale) devices
    /// through the "TokenX Connect (Wired)" or "Integration Hub" middleware.
    /// 
    /// Main Features:
    /// 1. POS Device Communication: Connects to POS hardware devices via Integration Hub
    /// 2. Basket Management: Creates, modifies, and submits shopping baskets to POS devices
    /// 3. Payment Processing: Handles various payment methods (cash, card)
    /// 4. Fiscal Information: Retrieves and displays fiscal data from connected POS devices
    /// 5. Advanced Operations: Supports special transactions like advances, invoice payments, etc.
    /// 
    /// Architecture:
    /// - Uses a callback-based approach for async communication with POS devices
    /// - Serializes/deserializes data using JSON for cross-platform compatibility
    /// - Implements a rich UI for basket and payment management
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The current shopping basket being constructed/modified
        /// Contains items, payment info, customer details, etc.
        /// </summary>
        private Basket basket;
        
        /// <summary>
        /// Reference to the POS communication interface
        /// This is the main integration point with the POS hardware
        /// </summary>
        private IntegrationHub.POSCommunication communication = Program.communication;
        
        /// <summary>
        /// Flag indicating whether a POS device is currently connected
        /// </summary>
        private bool isDeviceConnected = false;

        /// <summary>
        /// Callback method for handling serial data received from POS device
        /// 
        /// This method is invoked by the Integration Hub when data is received from the POS device.
        /// It processes various types of messages based on the 'type' parameter:
        /// - Type 3: Sale information (payment results)
        /// - Type 9: Basket processing errors
        /// 
        /// @param type The message type identifier
        /// @param value The message payload as a JSON string
        /// </summary>
        public void serialInCallback(int type, [MarshalAs(UnmanagedType.BStr)] string value)
        {
            Task.Run(() =>
            {
                string storeValue = string.Copy(value);
                updateConsole(storeValue);

                if (type == 9)
                {
                    this.Invoke(new Action(() =>
                    {
                        string message = "Sepet POS tarafından işlenemedi lütfen POS uygulamasının açık olduğuna emin olup tekrar deneyiniz!";
                        string caption = "Sepet İşlenemedi";
                        MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    }));
                }

                if (type == 3)
                {
                    try
                    {
                        ReceiptInfo receiptInfo = constructReceiptInfoFromJson(storeValue);
                        string message = "";

                        if (receiptInfo.status == 0)
                        {
                            message = "Ödeme başarılı!";
                            clearBasket();
                        }
                        else
                        {
                            message = "Ödeme başarısız";
                        }

                        this.Invoke(new Action(() =>
                        {
                            string caption = "Ödeme bilgisi alındı";
                            MessageBox.Show(message, caption, MessageBoxButtons.OK);
                        }));
                    }
                    catch
                    {
                        Console.WriteLine("ERROR");
                    }
                }

                Console.WriteLine($"\nTokenDotNet serialInCallback type: {type}\n");
                Console.WriteLine($"TokenDotNet serialInCallback value: {storeValue}\n");
                Console.WriteLine($"TokenDotNet serialInCallback basket: {constructJsonFromBasket(basket)}\n");
            });
        }

        public void deviceStateCallback(bool isConnected, [MarshalAs(UnmanagedType.BStr)] string id)
        {
            Task.Run(() =>
            {
                string idcpy = string.Copy(id);
                Console.WriteLine($"TokenDotNet deviceStateCallback isConnected: {isConnected}");
                Console.WriteLine($"TokenDotNet deviceStateCallback fiscalId: {id}");

                isDeviceConnected = isConnected;

                if (isConnected)
                {
                    this.Invoke(new Action(() => tbAvInfo.Text = idcpy));
                    Thread thread = new Thread(getFiscalInfo);
                    thread.Start();
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        tbAvInfo.Text = "Bağlı cihaz yok!";
                        lbFiscal.Items.Clear();
                        lbSavedItems.Items.Clear();
                    }));
                }
            });

        }

        private FiscalInfo constructFiscalInfoFromJson(string json)
        {
            return JsonConvert.DeserializeObject<FiscalInfo>(json);
        }
        private ReceiptInfo constructReceiptInfoFromJson(string json)
        {
            return JsonConvert.DeserializeObject<ReceiptInfo>(json);
        }

        private string constructJsonFromBasket(Basket basket)
        {
            string json = JsonConvert.SerializeObject(basket);
            Console.WriteLine(json);
            return json;
        } 
        
        private string constructJsonFromPayment(PaymentItem payment)
        {
            string json = JsonConvert.SerializeObject(payment);
            Console.WriteLine(json);
            return json;
        }

        private void updateConsole(string text)
        {
            if (tbConsole.InvokeRequired)
            {
                tbConsole.Invoke(new Action(() => tbConsole.Text = text));
            }
            else
            {
                tbConsole.Text = text;
            }
        }

        private void updateBasketView()
        {
            lbBasket.Items.Clear();
            foreach (Item item in basket.items)
            {
                lbBasket.Items.Add(item);
            }

            lbPrice.Text = $"{realPriceToDisplayPrice(basket.calculatePrice())}TL";
            lbPaymentPlan.Text = basket.paymentItems.Count == 0 ? "Yok" : "Var";
            lbCustomer.Text = basket.customerInfo == null ? "Yok" : basket.customerInfo.name;
            lbDiscount.Text = basket.adjust == null ? "Yok" : "Var";
        }

        private void clearBasket()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    basket = new Basket();
                    updateConsole(constructJsonFromBasket(basket));
                    updateBasketView();
                }));
            }
            else
            {
                basket = new Basket();
                updateConsole(constructJsonFromBasket(basket));
                updateBasketView();
            }
        }

        private void sendBasketWithPopup()
        {
            //IF DEVICE IS NOT CONNECTED
            if (!isDeviceConnected)
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "POS cihazı bağlayıp tekrar deneyiniz.";
                string caption = "Bağlı Cihaz Yok";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                }
                return;
            }

            //IF TOTAL PRICE IS 0 DON'T SEND BASKET
            if (basket.calculatePrice() <= 0)
            {
                {
                    // Initializes the variables to pass to the MessageBox.Show method.
                    string message = "Sepet tutarı sıfır veya sıfırdan küçük olamaz!";
                    string caption = "Sepet Gönderilemedi";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        // Closes the parent form.
                    }
                }
                return;
            }

            //IF BASKET IS EMPTY DON'T SEND BASKET
            if (basket.items.Count == 0)
            {
                {
                    // Initializes the variables to pass to the MessageBox.Show method.
                    string message = "Sepet boş gönderilemez!";
                    string caption = "Sepet Gönderilemedi";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        // Closes the parent form.
                    }
                }
                return;
            }
            int basketStatus = communication.sendBasket(constructJsonFromBasket(basket));

            //SEPET BİLGİSİ POSA ULAŞTI
            if (basketStatus == 1)
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "Sepet POS cihazına gönderildi.";
                string caption = "Sepet Gönderildi";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                }
            }

            //SEPET BİLGİSİ POSA ULAŞAMADI
            if (basketStatus == 0)
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "POS cihazı bağlantısı bulunamadı, gönderdiğiniz sepet sıraya eklendi bağlantı sağlandığında gönderilecek.";
                string caption = "Sepet Sıraya Eklendi";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                }
            }
        }

        private void sendCustomBasket(Basket basket)
        {
            //IF DEVICE IS NOT CONNECTED
            if (!isDeviceConnected)
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "POS cihazı bağlayıp tekrar deneyiniz.";
                string caption = "Bağlı Cihaz Yok";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                }
                return;
            }
              
            int basketStatus = communication.sendBasket(constructJsonFromBasket(basket));

            //SEPET BİLGİSİ POSA ULAŞTI
            if (basketStatus == 1)
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "Sepet POS cihazına gönderildi.";
                string caption = "Sepet Gönderildi";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                }
            }

            //SEPET BİLGİSİ POSA ULAŞAMADI
            if (basketStatus == 0)
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "POS cihazı bağlantısı bulunamadı, gönderdiğiniz sepet sıraya eklendi bağlantı sağlandığında gönderilecek.";
                string caption = "Sepet Sıraya Eklendi";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                }
            }
        }

        private Item castPlusToItem(Plus plus)
        {
            return (new Item
            {
                barcode = plus.barcode,
                name = plus.name,
                pluNo = plus.pluNo,
                price = plus.price,
                sectionNo = plus.sectionNo,
                taxPercent = plus.taxPercent,
                type = plus.type,
                unit = plus.unit,
                vatID = plus.vatID,
                limit = 0,
                quantity = 1000,
                paymentType = 0
            });
        }

        private void setUpCallbacks()
        {
            communication.setDeviceStateCallback(deviceStateCallback);
            communication.setSerialInCallback(serialInCallback);
        }

        private string getDllVersion()
        {
            string dllName = "IntegrationHub";
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                AssemblyName assemblyName = assembly.GetName();
                if (assemblyName.Name == dllName)
                    return assemblyName.Version.ToString();
            }

            return null;
        }

        public MainForm()
        {
            Thread thread = new Thread(setUpCallbacks);
            thread.Start();

            basket = new Basket();
            basket.basketID = "93ced0be-99f5-4e42-b0ca-bc781c778d69";
            basket.createInvoice = false;
            basket.documentType = 0;
            basket.isVoid = false;

            InitializeComponent();
            exSaleSelector.SelectedIndex = 0;
            lbVersion.Text = $"APP Version = {Assembly.GetExecutingAssembly().GetName().Version}";
            string dllVersion = getDllVersion();
            if (dllVersion != null)
                lbDllVersion.Text = $"DLL Version = {dllVersion}";
        }

        private void getFiscalInfo()
        {
            string fiscalInfo = communication.getFiscalInfo();

            if (string.IsNullOrEmpty(fiscalInfo))
            {
                Console.WriteLine("TokenDotNet FISCAL INFO IS NULL");
                return;
            }

            updateConsole(fiscalInfo);

            this.Invoke(new Action(() =>
            {
                lbFiscal.DisplayMember = "name";
                lbSavedItems.DisplayMember = "name";

                FiscalInfo fiscalinfoObj = constructFiscalInfoFromJson(fiscalInfo);

                lbFiscal.Items.Clear();
                lbSavedItems.Items.Clear();

                if (fiscalinfoObj.sections != null)
                {
                    foreach (Section section in fiscalinfoObj.sections)
                    {
                        lbFiscal.Items.Add(section);
                    }
                }

                if (fiscalinfoObj.plus != null)
                {
                    foreach (Plus item in fiscalinfoObj.plus)
                    {
                        lbSavedItems.Items.Add(item);
                    }
                }
            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("TokenDotNet get fiscalInfo onBtnClick" );
            if (!isDeviceConnected)
            {
                string message = "POS cihazı bağlayıp tekrar deneyiniz.";
                string caption = "Bağlı Cihaz Yok";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes)
                {
                }

                return;
            }

            Thread thread = new Thread(getFiscalInfo);
            thread.Start();
        }

        //pos takılı ama hızlı sepet kapalıyken blockluyor programı
        private void button3_Click(object sender, EventArgs e)
        {
            sendBasketWithPopup();
        }

        private void sendPayment(int type, string description = null)
        {
            if (basket.paymentItems.Count != 0)
            {
                string message = "Ödeme planı varken sepet gönder butonunu kullanınız!";
                string caption = "Sepet Gönderilemedi";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, caption, buttons);
                
                if (result == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
            }
            else
            {
                if (communication.getActiveDeviceIndex() == 1)
                {
                    int amount = displayPriceToRealPrice(tbItemPrice.Text);
                    string json = constructJsonFromPayment(new PaymentItem
                    {
                        amount = amount,
                        description = description,
                        type = type,
                    });
                    communication.sendPayment(json);
                }
                else
                {
                    basket.paymentItems.Add(new PaymentItem
                    {
                        amount = basket.calculatePrice(),
                        description = description,
                        type = type,
                    });

                    updateConsole(constructJsonFromBasket(basket));
                    updateBasketView();

                    sendBasketWithPopup();
                }
            }
        }

        private void sendCash_Click(object sender, EventArgs e)
        {
            sendPayment(1, "NAKIT");
        }

        private void sendCard_Click(object sender, EventArgs e)
        {
            sendPayment(3, "KREDI KARTI");
        }

        private void sendFoodCard_Click(object sender, EventArgs e)
        {
            sendPayment(7, "YEMEK KARTI");
        }

        private void addCustomer_Click(object sender, EventArgs e)
        {
            basket.customerInfo = new CustomerInfo
            {
                buildingName = "Building B",
                buildingNumber = "202",
                cityName = "City Y",
                citySubdivisonName = "Subdivision 2",
                country = "Country B",
                email = "customer2@example.com",
                isLock = false,
                name = "Ege Yardımcı",
                postalZone = "67890",
                region = "Region Y",
                room = "20",
                street = "Street B",
                taxID = "0987654321",
                taxScheme = "Scheme B",
                telefax = "654321",
                telephone = "0123456789"
            };
            basket.documentType = 2;
            updateConsole(constructJsonFromBasket(basket));
            updateBasketView();
        }

        private void removeCustomer_Click(object sender, EventArgs e)
        {
            basket.documentType = 0;
            basket.customerInfo = null;
            updateConsole(constructJsonFromBasket(basket));
            updateBasketView();
        }

        private void addPaymentPlan_Click(object sender, EventArgs e)
        {
            basket.paymentItems.Add(new PaymentItem
            {
                description = "NAKIT",
                amount = basket.calculatePrice()/2,
                type = 1,
            });

            basket.paymentItems.Add(new PaymentItem
            {
                description = "KREDI KARTI",
                amount = basket.calculatePrice()/2,
                type = 3,
            });
            updateConsole(constructJsonFromBasket(basket));
            updateBasketView();
        }

        private void removePaymentPlan_Click(object sender, EventArgs e)
        {
            basket.paymentItems = new List<PaymentItem>();
            updateConsole(constructJsonFromBasket(basket));
            updateBasketView();
        }

        private void addDiscount_Click(object sender, EventArgs e)
        {
            basket.adjust = new Adjust
            {
                description = "20 tl indirim",
                discountOrSurcharge = 0,
                type = 0,
                value = 2000
            };
            updateConsole(constructJsonFromBasket(basket));
            updateBasketView();
        }

        private void addSurcharge_Click(object sender, EventArgs e)
        {
            basket.adjust = new Adjust
            {
                description = "yüzde 20 arttırım",
                discountOrSurcharge = 1,
                type = 1,
                value = 2000
            };
            updateConsole(constructJsonFromBasket(basket));
            updateBasketView();
        }

        private void removeDiscount_Click(object sender, EventArgs e)
        {
            basket.adjust = null;
            updateConsole(constructJsonFromBasket(basket));
            updateBasketView();
        }

        private void deleteLastItemInBasket_Click(object sender, EventArgs e)
        {
            List<Item> itemList = new List<Item> { };
            for(int i = 0; i < basket.items.Count-1; i++)
            {
                itemList.Add(basket.items[i]);
            }

            basket.items = itemList;
            updateConsole(constructJsonFromBasket(basket));
            updateBasketView();
        }

        private void emptyBasket_Click(object sender, EventArgs e)
        {
            basket = new Basket();
            updateConsole(constructJsonFromBasket(basket));
            updateBasketView();

        }

        private int displayPriceToRealPrice(string str)
        {
            return (int)(Math.Round(decimal.Parse(str), 2) * 100);
        }

        private string realPriceToDisplayPrice(int price)
        {
            return ((decimal)price / 100).ToString();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
            if(tbItemPrice.Text == "")
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "Lütfen ürün fiyatı giriniz!";
                string caption = "Sepete eklenemedi";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                }
                return;
            }   

            Section section = lbFiscal.SelectedItem as Section;

            if(section == null)
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "Lütfen eklemek istediğiniz kısımı giriniz!";
                string caption = "Sepet Gönderilemedi";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                }
                return;
            }

            basket.items.Add(new Item
            {
                barcode = "",
                name = section.name,
                pluNo = 0,
                price = displayPriceToRealPrice(tbItemPrice.Text),
                sectionNo = section.sectionNo,
                taxPercent = section.taxPercent,
                type = 0,
                unit = "Adet",
                vatID = 0,
                limit = 0,
                quantity = 1000,
                paymentType = 0
            });
            updateConsole(constructJsonFromBasket(basket));
            updateBasketView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((Plus)lbSavedItems.SelectedItem != null)
            {
                Item item = castPlusToItem((Plus)lbSavedItems.SelectedItem);
                basket.items.Add(item);
                updateConsole(constructJsonFromBasket(basket));
                updateBasketView();
            }
            else
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "Lüften eklemek istediğiniz ürünü seçip tekrar deneyin!";
                string caption = "Sepete eklenemedi";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                }
            }
            return;
        }

        private void removeSelectedFromBasket_Click(object sender, EventArgs e)
        {
            if(lbBasket.SelectedIndex == -1)
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "Lütfen bir ürün seçiniz!";
                string caption = "İşlem yapılamadı";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                }
                return;
            }
            basket.items.RemoveAt(lbBasket.SelectedIndex);
            updateConsole(constructJsonFromBasket(basket));
            updateBasketView();
        }

        private void clearConsole(object sender, MouseEventArgs e)
        {
            tbConsole.Clear();
        }

        private void lbFiscal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbItemPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void exSale_Click(object sender, EventArgs e)
        {

            if (lbFiscal.Items.Count > 0)
            {
                var section = lbFiscal.Items[0] as Section;
                basket.items.Add(new Item
                {
                    barcode = "",
                    name = section.name,
                    pluNo = 0,
                    price = 10000,
                    sectionNo = section.sectionNo,
                    taxPercent = section.taxPercent,
                    type = 0,
                    unit = "Adet",
                    vatID = 0,
                    limit = 0,
                    quantity = 1000,
                    paymentType = 0
                });
                basket.paymentItems.Add(new PaymentItem
                {
                    amount = basket.calculatePrice(),
                    description = "NAKIT",
                    type = 1
                });
                updateConsole(constructJsonFromBasket(basket));
                updateBasketView();
                sendBasketWithPopup();
            }
            else
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "Lütfen önce kısımları çekiniz!";
                string caption = "";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes)
                {
                    // Closes the parent form.
                }
            }
        }

        private void exSaleSelectorHandle(object sender, EventArgs e) 
        {
            ComboBox selector = sender as ComboBox;
            if (selector.SelectedIndex == 0)
                return;
            
            Basket exmBasket = new Basket();
            exmBasket.basketID = "93ced0be-99f5-4e42-b0ca-bc781c778d69";
            exmBasket.createInvoice = false;
            exmBasket.documentType = 0;
            exmBasket.isVoid = false;

            string selectedItem = selector.SelectedItem as string;
            switch (selectedItem)
            {
                case "Avans":
                    using (AvansForm avansForm = new AvansForm()) {
                        DialogResult result = avansForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            CustomerInfo customerInfo = new CustomerInfo();
                            customerInfo.name = avansForm.name;
                            customerInfo.taxID = avansForm.taxId;

                            exmBasket.customerInfo = customerInfo;
                            exmBasket.documentType = 9000;
                            exmBasket.taxFreeAmount = avansForm.taxFreeAmount;

                            sendCustomBasket(exmBasket);
                        }
                    }
                    break;
                case "Fatura Tahsilatı":
                    using (FaturaTahsilatForm faturaTahsilatForm = new FaturaTahsilatForm())
                    {
                        DialogResult result = faturaTahsilatForm.ShowDialog();
                        if (result == DialogResult.OK )
                        {
                            InfoReceiptInfo infoReceiptInfo = new InfoReceiptInfo();
                            infoReceiptInfo.companyName = faturaTahsilatForm.companyName;
                            infoReceiptInfo.documentDate = faturaTahsilatForm.date;
                            infoReceiptInfo.documentNo = "6226";
                            infoReceiptInfo.subscriberNo = "6565";

                            exmBasket.infoReceiptInfo = infoReceiptInfo;
                            exmBasket.documentType = 9001;
                            exmBasket.taxFreeAmount = faturaTahsilatForm.taxFreeAmount;
                            exmBasket.items = basket.items;

                            sendCustomBasket(exmBasket);
                        }
                    }
                    break;
                case "Cari Tahsilat":
                    using (CariTahsilatForm cariTahsilatForm = new CariTahsilatForm()) 
                    {
                        DialogResult result = cariTahsilatForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            CustomerInfo customerInfo = new CustomerInfo();
                            customerInfo.name = cariTahsilatForm.name;
                            customerInfo.taxID = cariTahsilatForm.taxId;

                            InfoReceiptInfo infoReceiptInfo = new InfoReceiptInfo();
                            infoReceiptInfo.companyName = "";
                            infoReceiptInfo.documentDate = cariTahsilatForm.date;
                            infoReceiptInfo.documentNo = "568653";
                            infoReceiptInfo.subscriberNo = "";

                            exmBasket.customerInfo = customerInfo;
                            exmBasket.infoReceiptInfo = infoReceiptInfo;
                            exmBasket.documentType = 9002;
                            exmBasket.taxFreeAmount = cariTahsilatForm.taxFreeAmount;

                            sendCustomBasket(exmBasket);
                        }
                    }
                    break;
                case string type when type == "Fatura Bilgi Fişi" || type == "E-Fatura Bilgi Fişi" || type == "E-Arşiv Fatura Bilgi Fişi":
                    using (FaturaBilgiFisiForm faturaBilgiFisiForm = new FaturaBilgiFisiForm())
                    {
                        DialogResult result = faturaBilgiFisiForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            CustomerInfo customerInfo = new CustomerInfo();
                            customerInfo.taxID = faturaBilgiFisiForm.taxId;

                            InfoReceiptInfo infoReceiptInfo = new InfoReceiptInfo();
                            infoReceiptInfo.serialNo = faturaBilgiFisiForm.serialNo;

                            exmBasket.customerInfo = customerInfo;
                            exmBasket.infoReceiptInfo = infoReceiptInfo;
                            exmBasket.items = basket.items;
                            exmBasket.isWayBill = false;
                            exmBasket.documentType = (type == "Fatura Bilgi Fişi") ? 9005 : (type == "E-Fatura Bilgi Fişi") ? 9006 : 9007;

                            sendCustomBasket(exmBasket);
                        }
                    }
                    break;
                default:
                    break;
            }

            selector.SelectedIndex = 0;
        }

        private void disconnect_communication(object sender, EventArgs e)
        {
            try
            {
                communication.deleteCommunication();
                Console.WriteLine("Disconnectinggggg");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void reConnect_communication(object sender, EventArgs e)
        {
            try
            {
                communication.reConnect();
                Console.WriteLine("ReConnectinggggg");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void handleSendJsonButton(object sender, EventArgs e)
        {
            using (SendJsonForm popup = new SendJsonForm())
            {

                DialogResult result = popup.ShowDialog();
                if (result == DialogResult.OK || result == DialogResult.Yes)
                {
                    if (!isDeviceConnected)
                    {
                        string message = "POS cihazı bağlayıp tekrar deneyiniz.";
                        string caption = "Bağlı Cihaz Yok";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult _result;

                        _result = MessageBox.Show(message, caption, buttons);
                        if (_result == DialogResult.Yes) this.Close();

                        return;
                    }

                    string userInput = popup.UserInput;
                    try
                    {
                        // parsing to check if it is real json object
                        var obj = JsonConvert.DeserializeObject<object>(Regex.Unescape(userInput));

                        string json = JsonConvert.SerializeObject(obj);
                        Console.WriteLine(json);
                        if (result == DialogResult.OK)
                            communication.sendBasket(json);
                        else
                            communication.sendPayment(json);
                    }
                    catch (JsonException)
                    {
                        string message = "Geçerli bir json objesiyle tekrar deneyiniz.";
                        string caption = "Geçersiz Json";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult _result;

                        _result = MessageBox.Show(message, caption, buttons);
                        if (_result == DialogResult.Yes) this.Close();
                        
                        return;
                    }
                }
            }
        }

        private void handleCancelReceipt(object sender, EventArgs e)
        {
            if (!isDeviceConnected)
            {
                string message = "POS cihazı bağlayıp tekrar deneyiniz.";
                string caption = "Bağlı Cihaz Yok";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult _result;

                _result = MessageBox.Show(message, caption, buttons);
                if (_result == DialogResult.Yes) this.Close();

                return;
            }

            int activeDeviceIndex = communication.getActiveDeviceIndex();
            if (activeDeviceIndex == 1)
            {
                communication.sendPayment("{\"isVoid\": true}");
            } 
            else
            {
                string message = "Sadece 300TR ile kullanılabilir";
                string caption = "Geçersiz Talep";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult _result;

                _result = MessageBox.Show(message, caption, buttons);
                if (_result == DialogResult.Yes) this.Close();
            }
        }

        private void handleAddNote(object sender, EventArgs e) 
        {
            using (AddNoteForm addNoteForm = new AddNoteForm())
            {
                DialogResult result = addNoteForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    basket.note = addNoteForm.UserInput;
                }
            } 
        }

        private void handleRemoveNote(object sender, EventArgs e) 
        {
            basket.note = null;
        }
    }

    public partial class SendJsonForm : Form
    {
        public string UserInput { get; private set; }

        public SendJsonForm()
        {

            TextBox inputTextBox = new TextBox
            {
                Location = new System.Drawing.Point(20, 20),
                Width = 260,
                Height = 260,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            this.Controls.Add(inputTextBox);

            Button cancelButton = new Button
            {
                Text = "İptal",
                Location = new System.Drawing.Point(40, 310),
                DialogResult = DialogResult.Cancel
            };
            this.Controls.Add(cancelButton);

            Button sendPaymentButton = new Button
            {
                Text = "Ödeme Gönder",
                Location = new System.Drawing.Point(120, 300),
                DialogResult = DialogResult.Yes,
                Height = 40,
            };
            sendPaymentButton.Click += (s, e) => { UserInput = inputTextBox.Text; };
            this.Controls.Add(sendPaymentButton);

            Button sendBasketButton = new Button
            {
                Text = "Sepet Gönder",
                Location = new System.Drawing.Point(200, 300),
                DialogResult = DialogResult.OK,
                Height = 40,
            };
            sendBasketButton.Click += (s, e) => { UserInput = inputTextBox.Text; };
            this.Controls.Add(sendBasketButton);


            this.Text = "Json Gönder";
            this.CancelButton = cancelButton;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(300, 360);
        }
    }

    public partial class AddNoteForm : Form
    {
        public string UserInput { get; private set; }

        public AddNoteForm()
        {

            TextBox inputTextBox = new TextBox
            {
                Location = new System.Drawing.Point(20, 20),
                Width = 260,
                Height = 260,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            this.Controls.Add(inputTextBox);

            Button cancelButton = new Button
            {
                Text = "İptal",
                Location = new System.Drawing.Point(40, 300),
                DialogResult = DialogResult.Cancel
            };
            this.Controls.Add(cancelButton);

            Button sendPaymentButton = new Button
            {
                Text = "Not Ekle",
                Location = new System.Drawing.Point(120, 300),
                DialogResult = DialogResult.OK,
            };
            sendPaymentButton.Click += (s, e) => { UserInput = inputTextBox.Text.Replace("\r",""); };
            this.Controls.Add(sendPaymentButton);


            this.Text = "Not Ekle";
            this.CancelButton = cancelButton;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(300, 340);
        }
    }
}
