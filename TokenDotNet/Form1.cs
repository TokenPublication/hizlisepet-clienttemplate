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

namespace TokenDotNet
{
    public partial class MainForm : Form
    {

        private Basket basket;
        private IntegrationHub.POSCommunication communication = Program.communication;
        private bool isDeviceConnceted = false;

        public void serialInCallback(int type, [MarshalAs(UnmanagedType.BStr)]  string value)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            string storeValue = string.Copy(value);

            updateConsole(storeValue);

            //BASKET PROCESS ERROR
            if(type == 9)
            {
                string message = "Sepet POS tarafından işlenemedi lütfen POS uygulamasının açık olduğuna emin olup tekrar deneyiniz!";
                string caption = "Sepet İşlenemedi";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
            }

            //SALE INFORMATION
            if(type == 3)
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                try
                {
                    Console.WriteLine("DATA FROM C++ IS: " + storeValue);
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
                    string caption = "Ödeme bilgisi alındı";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        // Closes the parent form.
                        this.Close();
                    }
                                        Console.WriteLine("DATA FROM C++ IS: " + storeValue);
                }
                catch
                {
                    Console.WriteLine("ERROR");
                }
            }
        }

        public void deviceStateCallback(bool isConnected, [MarshalAs(UnmanagedType.BStr)] string id)
        {
            string idcpy = string.Copy(id);
            Console.WriteLine("Device ID: " + id);
            Control.CheckForIllegalCrossThreadCalls = false;
            if (isConnected)
            {
                tbAvInfo.Text = idcpy;
                isDeviceConnceted = true;
            }
            else
            {
                isDeviceConnceted = false;
                Task.Run(() => {
                    if (tbAvInfo.InvokeRequired) { tbAvInfo.Invoke((MethodInvoker)(() => tbAvInfo.Text = "Bağlı cihaz yok!")); }
                    else tbAvInfo.Text = "Bağlı cihaz yok!";
                    Console.WriteLine("Items Freed1");
                });
                Task.Run(() => {
                    if (lbFiscal.InvokeRequired) { lbFiscal.Invoke((MethodInvoker)(() => lbFiscal.Items.Clear())); }
                    else lbFiscal.Items.Clear();
                    Console.WriteLine("Items Freed2");
                });
                Task.Run(() => {
                    if (lbSavedItems.InvokeRequired) { lbSavedItems.Invoke((MethodInvoker)(() => lbSavedItems.Items.Clear())); }
                    else lbSavedItems.Items.Clear();
                    Console.WriteLine("Items Freed3");
                });
                Console.WriteLine("Items Freed4");
            }
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
            string json = JsonConvert.SerializeObject(basket, Formatting.Indented);
            Console.WriteLine(json);
            return json;
        } 
        
        private string constructJsonFromPayment(PaymentItem payment)
        {
            string json = JsonConvert.SerializeObject(payment, Formatting.Indented);
            Console.WriteLine(json);
            return json;
        }

        private void updateConsole(string update)
        {
            tbConsole.AppendText(update);
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
            basket = new Basket();
            updateConsole(constructJsonFromBasket(basket));
            updateBasketView();
        }

        private void sendBasketWithPopup()
        {
            //IF DEVICE IS NOT CONNECTED
            if (!isDeviceConnceted)
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
                    this.Close();
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
                        this.Close();
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
                        this.Close();
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
                    this.Close();
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
                    this.Close();
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

        public MainForm()
        {
            InitializeComponent();

            Thread thread = new Thread(setUpCallbacks);
            thread.Start();

            basket = new Basket();
            basket.basketID = "93ced0be-99f5-4e42-b0ca-bc781c778d69";
            basket.createInvoice = false;
            basket.documentType = 0;
            basket.isVoid = false;

            lbVersion.Text = Program.version;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
 

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isDeviceConnceted)
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
                    this.Close();
                }
                return;
            }
            string fiscalInfo = communication.getFiscalInfo();
            updateConsole(fiscalInfo);

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

        }

        //pos takılı ama hızlı sepet kapalıyken blockluyor programı
        private void button3_Click(object sender, EventArgs e)
        {
            sendBasketWithPopup();
        }

        private void sendCash_Click(object sender, EventArgs e)
        {
            if (basket.paymentItems.Count != 0)
            {
                {
                    // Initializes the variables to pass to the MessageBox.Show method.
                    string message = "Ödeme planı varken sepet gönder butonunu kullanınız!";
                    string caption = "Sepet Gönderilemedi";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        // Closes the parent form.
                        this.Close();
                    }
                }
            }
            else
            {
                if (communication.getActiveDeviceIndex() == 1)
                {
                    int amount = displayPriceToRealPrice(tbItemPrice.Text);
                    string json = constructJsonFromPayment(new PaymentItem
                    {
                        amount = amount,
                        description = "nakit ödeme",
                        taxRate = 5,
                        type = 1
                    });
                    communication.sendPayment(json);
                }
                else
                {
                    basket.paymentItems.Add(new PaymentItem
                    {
                        amount = basket.calculatePrice(),
                        description = "Tum tutarı nakit olarak odet",
                        taxRate = 5,
                        type = 1
                    });
                
                    updateConsole(constructJsonFromBasket(basket));
                    updateBasketView();

                    sendBasketWithPopup();
                }
            }
        }

        private void sendCard_Click(object sender, EventArgs e)
        {
            if (basket.paymentItems.Count != 0)
            {
                {
                    // Initializes the variables to pass to the MessageBox.Show method.
                    string message = "Ödeme planı varken sepet gönder butonunu kullanınız!";
                    string caption = "Sepet Gönderilemedi";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        // Closes the parent form.
                        this.Close();
                    }
                }
            }
            else
            {
                if (communication.getActiveDeviceIndex() == 1)
                {
                    int amount = displayPriceToRealPrice(tbItemPrice.Text);
                    string json = constructJsonFromPayment(new PaymentItem
                    {
                        amount = amount,
                        description = "kart ödeme",
                        taxRate = 5,
                        type = 3
                    });
                    communication.sendPayment(json);
                }
                else
                {
                    basket.paymentItems.Add(new PaymentItem
                    {
                        amount = basket.calculatePrice(),
                        description = "Tum tutari kart olarak odet",
                        taxRate = 5,
                        type = 3
                    });

                    updateConsole(constructJsonFromBasket(basket));
                    updateBasketView();

                    sendBasketWithPopup();
                }
            }
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
                description = "yarısı nakit",
                amount = basket.calculatePrice()/2,
                type = 1,
                taxRate = 5
            });

            basket.paymentItems.Add(new PaymentItem
            {
                description = "yarısı kredi kartı",
                amount = basket.calculatePrice()/2,
                type = 3,
                taxRate = 5
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

        private void addAppleToBasket_Click(object sender, EventArgs e)
        {
            basket.items.Add(new Item
            {
                barcode = "",
                name = "Su",
                pluNo = 0,
                price = 500,
                sectionNo = 1,
                taxPercent = 1000,
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

        private void addPearToBasket_Click(object sender, EventArgs e)
        {
            basket.items.Add(new Item
            {
                barcode = "",
                name = "Armut Ülker",
                pluNo = 0,
                price = 1500,
                sectionNo = 1,
                taxPercent = 1000,
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
                    this.Close();
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
                    this.Close();
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
                    this.Close();
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
                    this.Close();
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

        private void lbPrice_Click(object sender, EventArgs e)
        {

        }

        private void exSale_Click(object sender, EventArgs e)
        {
            string example = "{\r\n  \"UUID\": \"dedddcdf-0938-46b9-b18b-d268bfc2f1fa\",\r\n  \"amount\": 0,\r\n  \"basketID\": \"dcd8e72c-ca4c-4246-8598-bceea8a635ff\",\r\n  \"clientid\": \"com.tokeninc.ecr\",\r\n  \"createdTime\": 1731065762,\r\n  \"customerInfo\": {\r\n    \"name\": \"\",\r\n    \"taxID\": \"68533094750\"\r\n  },\r\n  \"documentType\": 9007,\r\n  \"enableSecondScreen\": false,\r\n  \"firstCheck\": \"\",\r\n  \"id\": 0,\r\n  \"infoReceiptInfo\": {\r\n    \"serialNo\": \"FSD\"\r\n  },\r\n  \"InstanceIdentifier\": \"\",\r\n  \"invoiceCollectionSequentialNo\": \"\",\r\n  \"invoiceID\": \"\",\r\n  \"isPowerCut\": false,\r\n  \"isVoid\": false,\r\n  \"isWayBill\": false,\r\n  \"items\": [\r\n    {\r\n      \"name\": \"Yiyecek\",\r\n      \"price\": 45000,\r\n      \"quantity\": 1000.0,\r\n      \"sectionNo\": 1,\r\n      \"taxPercent\": 1000.0\r\n    }\r\n  ],\r\n  \"packageName\": \"com.tokeninc.ecr\",\r\n  \"paymentCount\": 1,\r\n  \"paymentScreen\": 0,\r\n  \"paymentItems\": [\r\n    {\r\n      \"amount\": 45000.0,\r\n      \"BatchNo\": 0,\r\n      \"currencyId\": 0,\r\n      \"description\": \"Nakit\",\r\n      \"operatorId\": 0,\r\n      \"status\": -1,\r\n      \"taxRate\": -1,\r\n      \"TxnNo\": 0,\r\n      \"type\": 1\r\n    }\r\n  ],\r\n  \"price\": 0,\r\n  \"quantity\": 0,\r\n  \"receiptNo\": \"7\",\r\n  \"resultObject\": {},\r\n  \"sessionID\": \"\",\r\n  \"splitRate\": 0,\r\n  \"state\": 3,\r\n  \"status\": 0,\r\n  \"totalValue\": 0.0,\r\n  \"type\": 0,\r\n  \"uuid\": \"\",\r\n  \"value\": 0.0,\r\n  \"voidPrice\": 0,\r\n  \"voidQuantity\": 0,\r\n  \"zNo\": \"22\"\r\n}";
            communication.sendBasket(example);
            //basket.items.Add(new Item
            //{
            //    barcode = "",
            //    name = "GIDA",
            //    pluNo = 0,
            //    price = 10000,
            //    sectionNo = 10,
            //    taxPercent = 1700,
            //    type = 0,
            //    unit = "Adet",
            //    vatID = 0,
            //    limit = 0,
            //    quantity = 1000,
            //    paymentType = 0
            //});
            //updateConsole(constructJsonFromBasket(basket));
            //updateBasketView();
            //sendBasketWithPopup();
        }

        private void disconnect_communication(object sender, EventArgs e)
        {
            communication.deleteCommunication();
        }

        private void handleSendJsonButton(object sender, EventArgs e)
        {
            using (PopupForm popup = new PopupForm())
            {
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    // Retrieve the input from the popup
                    string userInput = popup.UserInput;

                    if (!isDeviceConnceted)
                    {
                        string message = "POS cihazı bağlayıp tekrar deneyiniz.";
                        string caption = "Bağlı Cihaz Yok";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;

                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            // Closes the parent form.
                            this.Close();
                        }
                        return;
                    }

                    try
                    {
                        // parsing to check if it is real json object
                        string escapedUserInput = Regex.Unescape(userInput);
                        var obj = JsonConvert.DeserializeObject<object>(escapedUserInput);
                        Console.WriteLine(escapedUserInput);

                        communication.sendBasket(userInput);
                    }
                    catch (JsonException)
                    {
                        string message = "Geçerli bir json objesiyle tekrar deneyiniz.";
                        string caption = "Geçersiz Json";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;

                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            // Closes the parent form.
                            this.Close();
                        }
                        return;
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void lbVersion_Click(object sender, EventArgs e)
        {

        }
    }

    public partial class PopupForm : Form
    {
        public string UserInput { get; private set; }

        public PopupForm()
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
                Location = new System.Drawing.Point(120, 300),
                DialogResult = DialogResult.Cancel
            };
            this.Controls.Add(cancelButton);

            Button okButton = new Button
            {
                Text = "Gönder",
                Location = new System.Drawing.Point(200, 300),
                DialogResult = DialogResult.OK
            };
            okButton.Click += (s, e) => { UserInput = inputTextBox.Text; };
            this.Controls.Add(okButton);

            this.Text = "Json Gönder";
            this.AcceptButton = okButton;
            this.CancelButton = cancelButton;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(300, 340);
        }
    }
}
