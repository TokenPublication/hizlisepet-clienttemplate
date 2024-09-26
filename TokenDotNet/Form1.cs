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

namespace TokenDotNet
{
    public partial class MainForm : Form
    {

        private Basket basket;
        private IntegrationHub.POSCommunication communication = Program.communication;
        private bool isDeviceConnceted = false;

        public int serialInCallback(int type, string value)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            tbConsole.AppendText(value);

            if(type == 3)
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                try
                {
                    ReceiptInfo receiptInfo = constructReceiptInfoFromJson(value);
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
                }
                catch
                {
                    Console.WriteLine("ERROR");
                }
            }

            return 1;
        }

        public void deviceStateCallback(bool isConnected, string id)
        {

            Control.CheckForIllegalCrossThreadCalls = false;
            if (isConnected)
            {
                tbAvInfo.Text = id;
                isDeviceConnceted = true;
            }
            else
            {
                isDeviceConnceted = false;
                tbAvInfo.Text = "Bağlı cihaz yok!";
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
            return JsonConvert.SerializeObject(basket, Formatting.Indented);
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

            if (fiscalinfoObj.sections.Count != 0)
            {
                foreach (Section section in fiscalinfoObj.sections)
                {
                    lbFiscal.Items.Add(section);
                }
            }

            if (fiscalinfoObj.plus.Count != 0)
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
            return (int)((float)Math.Round(float.Parse(str), 2) * 100);
        }

        private string realPriceToDisplayPrice(int price)
        {
            return ((float)price / 100).ToString();
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
            basket.items.Add(new Item
            {
                barcode = "",
                name = "GIDA",
                pluNo = 0,
                price = 10000,
                sectionNo = 10,
                taxPercent = 1700,
                type = 0,
                unit = "Adet",
                vatID = 0,
                limit = 0,
                quantity = 1000,
                paymentType = 0
            });
            updateConsole(constructJsonFromBasket(basket));
            updateBasketView();
            sendBasketWithPopup();
        }
    }
}
