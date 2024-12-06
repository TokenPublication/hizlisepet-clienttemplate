using System.Windows.Forms;

namespace TokenDotNet
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbConsole = new System.Windows.Forms.RichTextBox();
            this.getFiscal = new System.Windows.Forms.Button();
            this.sendBasket = new System.Windows.Forms.Button();
            this.tbAvInfo = new System.Windows.Forms.TextBox();
            this.addCustomer = new System.Windows.Forms.Button();
            this.removeCustomer = new System.Windows.Forms.Button();
            this.removePaymentPlan = new System.Windows.Forms.Button();
            this.addPaymentPlan = new System.Windows.Forms.Button();
            this.addSurcharge = new System.Windows.Forms.Button();
            this.addDiscount = new System.Windows.Forms.Button();
            this.removeDiscount = new System.Windows.Forms.Button();
            this.sendCash = new System.Windows.Forms.Button();
            this.sendCard = new System.Windows.Forms.Button();
            this.addWaterToBasket = new System.Windows.Forms.Button();
            this.addPearToBasket = new System.Windows.Forms.Button();
            this.deleteLastItemInBasket = new System.Windows.Forms.Button();
            this.emptyBasket = new System.Windows.Forms.Button();
            this.lbBasket = new System.Windows.Forms.ListBox();
            this.lbSepet = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbSavedItems = new System.Windows.Forms.ListBox();
            this.addSelectedToBasket = new System.Windows.Forms.Button();
            this.removeSelectedFromBasket = new System.Windows.Forms.Button();
            this.addItemToBasket = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbFiscal = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbItemPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbCustomer = new System.Windows.Forms.Label();
            this.staticlb1 = new System.Windows.Forms.Label();
            this.lbPaymentPlan = new System.Windows.Forms.Label();
            this.staticlb2 = new System.Windows.Forms.Label();
            this.lbDiscount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbVersion = new System.Windows.Forms.Label();
            this.exSale = new System.Windows.Forms.Button();
            this.sendJson = new System.Windows.Forms.Button();
            this.exSaleSelector = new System.Windows.Forms.ComboBox();
            this.cancelReceipt = new System.Windows.Forms.Button();
            this.addNote = new System.Windows.Forms.Button();
            this.removeNote = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.reConnect = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbConsole
            // 
            this.tbConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbConsole.BackColor = System.Drawing.SystemColors.Control;
            this.tbConsole.Location = new System.Drawing.Point(542, 10);
            this.tbConsole.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ReadOnly = true;
            this.tbConsole.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbConsole.Size = new System.Drawing.Size(384, 395);
            this.tbConsole.TabIndex = 0;
            this.tbConsole.Text = "";
            this.tbConsole.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.clearConsole);
            // 
            // getFiscal
            // 
            this.getFiscal.Location = new System.Drawing.Point(9, 41);
            this.getFiscal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.getFiscal.Name = "getFiscal";
            this.getFiscal.Size = new System.Drawing.Size(128, 49);
            this.getFiscal.TabIndex = 2;
            this.getFiscal.Text = "Kayıtlı ürün ve kısımları getir";
            this.getFiscal.UseVisualStyleBackColor = true;
            this.getFiscal.Click += new System.EventHandler(this.button2_Click);
            // 
            // sendBasket
            // 
            this.sendBasket.Location = new System.Drawing.Point(9, 94);
            this.sendBasket.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sendBasket.Name = "sendBasket";
            this.sendBasket.Size = new System.Drawing.Size(128, 23);
            this.sendBasket.TabIndex = 3;
            this.sendBasket.Text = "Sepet gönder";
            this.sendBasket.UseVisualStyleBackColor = true;
            this.sendBasket.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbAvInfo
            // 
            this.tbAvInfo.BackColor = System.Drawing.SystemColors.Info;
            this.tbAvInfo.Location = new System.Drawing.Point(382, 10);
            this.tbAvInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbAvInfo.Name = "tbAvInfo";
            this.tbAvInfo.ReadOnly = true;
            this.tbAvInfo.Size = new System.Drawing.Size(132, 20);
            this.tbAvInfo.TabIndex = 4;
            this.tbAvInfo.Text = "Bağlı cihaz yok!";
            // 
            // addCustomer
            // 
            this.addCustomer.Location = new System.Drawing.Point(9, 173);
            this.addCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addCustomer.Name = "addCustomer";
            this.addCustomer.Size = new System.Drawing.Size(128, 23);
            this.addCustomer.TabIndex = 5;
            this.addCustomer.Text = "Müşteri ekle";
            this.addCustomer.UseVisualStyleBackColor = true;
            this.addCustomer.Click += new System.EventHandler(this.addCustomer_Click);
            // 
            // removeCustomer
            // 
            this.removeCustomer.Location = new System.Drawing.Point(9, 197);
            this.removeCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.removeCustomer.Name = "removeCustomer";
            this.removeCustomer.Size = new System.Drawing.Size(128, 23);
            this.removeCustomer.TabIndex = 6;
            this.removeCustomer.Text = "Müşteri kaldır";
            this.removeCustomer.UseVisualStyleBackColor = true;
            this.removeCustomer.Click += new System.EventHandler(this.removeCustomer_Click);
            // 
            // removePaymentPlan
            // 
            this.removePaymentPlan.Location = new System.Drawing.Point(9, 247);
            this.removePaymentPlan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.removePaymentPlan.Name = "removePaymentPlan";
            this.removePaymentPlan.Size = new System.Drawing.Size(128, 23);
            this.removePaymentPlan.TabIndex = 8;
            this.removePaymentPlan.Text = "Ödeme planı kaldır";
            this.removePaymentPlan.UseVisualStyleBackColor = true;
            this.removePaymentPlan.Click += new System.EventHandler(this.removePaymentPlan_Click);
            // 
            // addPaymentPlan
            // 
            this.addPaymentPlan.Location = new System.Drawing.Point(9, 224);
            this.addPaymentPlan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addPaymentPlan.Name = "addPaymentPlan";
            this.addPaymentPlan.Size = new System.Drawing.Size(128, 23);
            this.addPaymentPlan.TabIndex = 7;
            this.addPaymentPlan.Text = "Ödeme planı ekle";
            this.addPaymentPlan.UseVisualStyleBackColor = true;
            this.addPaymentPlan.Click += new System.EventHandler(this.addPaymentPlan_Click);
            // 
            // addSurcharge
            // 
            this.addSurcharge.Location = new System.Drawing.Point(9, 352);
            this.addSurcharge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addSurcharge.Name = "addSurcharge";
            this.addSurcharge.Size = new System.Drawing.Size(128, 23);
            this.addSurcharge.TabIndex = 10;
            this.addSurcharge.Text = "Arttırım ekle";
            this.addSurcharge.UseVisualStyleBackColor = true;
            this.addSurcharge.Click += new System.EventHandler(this.addSurcharge_Click);
            // 
            // addDiscount
            // 
            this.addDiscount.Location = new System.Drawing.Point(9, 328);
            this.addDiscount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addDiscount.Name = "addDiscount";
            this.addDiscount.Size = new System.Drawing.Size(128, 23);
            this.addDiscount.TabIndex = 9;
            this.addDiscount.Text = "İndirim ekle";
            this.addDiscount.UseVisualStyleBackColor = true;
            this.addDiscount.Click += new System.EventHandler(this.addDiscount_Click);
            // 
            // removeDiscount
            // 
            this.removeDiscount.Location = new System.Drawing.Point(9, 376);
            this.removeDiscount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.removeDiscount.Name = "removeDiscount";
            this.removeDiscount.Size = new System.Drawing.Size(128, 23);
            this.removeDiscount.TabIndex = 11;
            this.removeDiscount.Text = "İndirim / Arttırım kaldır";
            this.removeDiscount.UseVisualStyleBackColor = true;
            this.removeDiscount.Click += new System.EventHandler(this.removeDiscount_Click);
            // 
            // sendCash
            // 
            this.sendCash.Location = new System.Drawing.Point(9, 119);
            this.sendCash.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sendCash.Name = "sendCash";
            this.sendCash.Size = new System.Drawing.Size(128, 23);
            this.sendCash.TabIndex = 12;
            this.sendCash.Text = "Nakit gönder";
            this.sendCash.UseVisualStyleBackColor = true;
            this.sendCash.Click += new System.EventHandler(this.sendCash_Click);
            // 
            // sendCard
            // 
            this.sendCard.Location = new System.Drawing.Point(9, 143);
            this.sendCard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sendCard.Name = "sendCard";
            this.sendCard.Size = new System.Drawing.Size(128, 23);
            this.sendCard.TabIndex = 13;
            this.sendCard.Text = "Kredi kartı gönder";
            this.sendCard.UseVisualStyleBackColor = true;
            this.sendCard.Click += new System.EventHandler(this.sendCard_Click);
            // 
            // addWaterToBasket
            // 
            this.addWaterToBasket.Location = new System.Drawing.Point(0, 0);
            this.addWaterToBasket.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addWaterToBasket.Name = "addWaterToBasket";
            this.addWaterToBasket.Size = new System.Drawing.Size(56, 19);
            this.addWaterToBasket.TabIndex = 49;
            // 
            // addPearToBasket
            // 
            this.addPearToBasket.Location = new System.Drawing.Point(0, 0);
            this.addPearToBasket.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addPearToBasket.Name = "addPearToBasket";
            this.addPearToBasket.Size = new System.Drawing.Size(56, 19);
            this.addPearToBasket.TabIndex = 48;
            // 
            // deleteLastItemInBasket
            // 
            this.deleteLastItemInBasket.Location = new System.Drawing.Point(160, 347);
            this.deleteLastItemInBasket.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.deleteLastItemInBasket.Name = "deleteLastItemInBasket";
            this.deleteLastItemInBasket.Size = new System.Drawing.Size(128, 23);
            this.deleteLastItemInBasket.TabIndex = 16;
            this.deleteLastItemInBasket.Text = "Sepetteki son ürünü sil";
            this.deleteLastItemInBasket.UseVisualStyleBackColor = true;
            this.deleteLastItemInBasket.Click += new System.EventHandler(this.deleteLastItemInBasket_Click);
            // 
            // emptyBasket
            // 
            this.emptyBasket.Location = new System.Drawing.Point(160, 376);
            this.emptyBasket.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.emptyBasket.Name = "emptyBasket";
            this.emptyBasket.Size = new System.Drawing.Size(128, 23);
            this.emptyBasket.TabIndex = 17;
            this.emptyBasket.Text = "Sepeti sıfırla";
            this.emptyBasket.UseVisualStyleBackColor = true;
            this.emptyBasket.Click += new System.EventHandler(this.emptyBasket_Click);
            // 
            // lbBasket
            // 
            this.lbBasket.FormattingEnabled = true;
            this.lbBasket.Location = new System.Drawing.Point(422, 56);
            this.lbBasket.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbBasket.Name = "lbBasket";
            this.lbBasket.Size = new System.Drawing.Size(91, 303);
            this.lbBasket.TabIndex = 18;
            // 
            // lbSepet
            // 
            this.lbSepet.AutoSize = true;
            this.lbSepet.Location = new System.Drawing.Point(420, 37);
            this.lbSepet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSepet.Name = "lbSepet";
            this.lbSepet.Size = new System.Drawing.Size(35, 13);
            this.lbSepet.TabIndex = 19;
            this.lbSepet.Text = "Sepet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 222);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Kayıtlı ürünler";
            // 
            // lbSavedItems
            // 
            this.lbSavedItems.FormattingEnabled = true;
            this.lbSavedItems.Location = new System.Drawing.Point(314, 238);
            this.lbSavedItems.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbSavedItems.Name = "lbSavedItems";
            this.lbSavedItems.Size = new System.Drawing.Size(91, 121);
            this.lbSavedItems.TabIndex = 20;
            // 
            // addSelectedToBasket
            // 
            this.addSelectedToBasket.Location = new System.Drawing.Point(314, 363);
            this.addSelectedToBasket.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addSelectedToBasket.Name = "addSelectedToBasket";
            this.addSelectedToBasket.Size = new System.Drawing.Size(90, 41);
            this.addSelectedToBasket.TabIndex = 22;
            this.addSelectedToBasket.Text = "Seçili ürünü sepete ekle";
            this.addSelectedToBasket.UseVisualStyleBackColor = true;
            this.addSelectedToBasket.Click += new System.EventHandler(this.button1_Click);
            // 
            // removeSelectedFromBasket
            // 
            this.removeSelectedFromBasket.Location = new System.Drawing.Point(422, 363);
            this.removeSelectedFromBasket.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.removeSelectedFromBasket.Name = "removeSelectedFromBasket";
            this.removeSelectedFromBasket.Size = new System.Drawing.Size(90, 41);
            this.removeSelectedFromBasket.TabIndex = 23;
            this.removeSelectedFromBasket.Text = "Seçili ürünü sepetten kaldır";
            this.removeSelectedFromBasket.UseVisualStyleBackColor = true;
            this.removeSelectedFromBasket.Click += new System.EventHandler(this.removeSelectedFromBasket_Click);
            // 
            // addItemToBasket
            // 
            this.addItemToBasket.Location = new System.Drawing.Point(314, 179);
            this.addItemToBasket.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addItemToBasket.Name = "addItemToBasket";
            this.addItemToBasket.Size = new System.Drawing.Size(90, 37);
            this.addItemToBasket.TabIndex = 26;
            this.addItemToBasket.Text = "Seçili kısım ile ürün sepete ekle";
            this.addItemToBasket.UseVisualStyleBackColor = true;
            this.addItemToBasket.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Kayıtlı kısımlar";
            // 
            // lbFiscal
            // 
            this.lbFiscal.FormattingEnabled = true;
            this.lbFiscal.Location = new System.Drawing.Point(314, 54);
            this.lbFiscal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbFiscal.Name = "lbFiscal";
            this.lbFiscal.Size = new System.Drawing.Size(91, 121);
            this.lbFiscal.TabIndex = 24;
            this.lbFiscal.SelectedIndexChanged += new System.EventHandler(this.lbFiscal_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Ürün fiyatı";
            // 
            // tbItemPrice
            // 
            this.tbItemPrice.Location = new System.Drawing.Point(160, 56);
            this.tbItemPrice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbItemPrice.Name = "tbItemPrice";
            this.tbItemPrice.Size = new System.Drawing.Size(129, 20);
            this.tbItemPrice.TabIndex = 29;
            this.tbItemPrice.TextChanged += new System.EventHandler(this.tbItemPrice_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 89);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Sepet tutarı: ";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(222, 89);
            this.lbPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(26, 13);
            this.lbPrice.TabIndex = 32;
            this.lbPrice.Text = "0TL";
            this.lbPrice.Click += new System.EventHandler(this.lbPrice_Click);
            // 
            // lbCustomer
            // 
            this.lbCustomer.AutoSize = true;
            this.lbCustomer.Location = new System.Drawing.Point(202, 132);
            this.lbCustomer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCustomer.Name = "lbCustomer";
            this.lbCustomer.Size = new System.Drawing.Size(26, 13);
            this.lbCustomer.TabIndex = 34;
            this.lbCustomer.Text = "Yok";
            // 
            // staticlb1
            // 
            this.staticlb1.AutoSize = true;
            this.staticlb1.Location = new System.Drawing.Point(158, 132);
            this.staticlb1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.staticlb1.Name = "staticlb1";
            this.staticlb1.Size = new System.Drawing.Size(44, 13);
            this.staticlb1.TabIndex = 33;
            this.staticlb1.Text = "Müşteri:";
            // 
            // lbPaymentPlan
            // 
            this.lbPaymentPlan.AutoSize = true;
            this.lbPaymentPlan.Location = new System.Drawing.Point(222, 152);
            this.lbPaymentPlan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPaymentPlan.Name = "lbPaymentPlan";
            this.lbPaymentPlan.Size = new System.Drawing.Size(26, 13);
            this.lbPaymentPlan.TabIndex = 36;
            this.lbPaymentPlan.Text = "Yok";
            // 
            // staticlb2
            // 
            this.staticlb2.AutoSize = true;
            this.staticlb2.Location = new System.Drawing.Point(158, 152);
            this.staticlb2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.staticlb2.Name = "staticlb2";
            this.staticlb2.Size = new System.Drawing.Size(69, 13);
            this.staticlb2.TabIndex = 35;
            this.staticlb2.Text = "Ödeme planı:";
            this.staticlb2.Click += new System.EventHandler(this.staticlb2_Click);
            // 
            // lbDiscount
            // 
            this.lbDiscount.AutoSize = true;
            this.lbDiscount.Location = new System.Drawing.Point(199, 111);
            this.lbDiscount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDiscount.Name = "lbDiscount";
            this.lbDiscount.Size = new System.Drawing.Size(26, 13);
            this.lbDiscount.TabIndex = 38;
            this.lbDiscount.Text = "Yok";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 111);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "İndirim:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TokenDotNet.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(9, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(160, 11);
            this.lbVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(51, 13);
            this.lbVersion.TabIndex = 40;
            this.lbVersion.Text = "Version =";
            this.lbVersion.Click += new System.EventHandler(this.lbVersion_Click);
            // 
            // exSale
            // 
            this.exSale.Location = new System.Drawing.Point(160, 179);
            this.exSale.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exSale.Name = "exSale";
            this.exSale.Size = new System.Drawing.Size(128, 23);
            this.exSale.TabIndex = 41;
            this.exSale.Text = "Örnek Satış Gönder";
            this.exSale.UseVisualStyleBackColor = true;
            this.exSale.Click += new System.EventHandler(this.exSale_Click);
            // 
            // sendJson
            // 
            this.sendJson.Location = new System.Drawing.Point(160, 228);
            this.sendJson.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sendJson.Name = "sendJson";
            this.sendJson.Size = new System.Drawing.Size(128, 23);
            this.sendJson.TabIndex = 43;
            this.sendJson.Text = "Json Gönder";
            this.sendJson.UseVisualStyleBackColor = true;
            this.sendJson.Click += new System.EventHandler(this.handleSendJsonButton);
            // 
            // exSaleSelector
            // 
            this.exSaleSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exSaleSelector.Items.AddRange(new object[] {
            "Örnek Fiş Gönder",
            "Avans",
            "Fatura Tahsilatı",
            "Cari Tahsilat",
            "Fatura Bilgi Fişi",
            "E-Fatura Bilgi Fişi",
            "E-Arşiv Fatura Bilgi Fişi"});
            this.exSaleSelector.Location = new System.Drawing.Point(160, 252);
            this.exSaleSelector.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exSaleSelector.Name = "exSaleSelector";
            this.exSaleSelector.Size = new System.Drawing.Size(129, 21);
            this.exSaleSelector.TabIndex = 44;
            this.exSaleSelector.SelectedIndexChanged += new System.EventHandler(this.exSaleSelectorHandle);
            // 
            // cancelReceipt
            // 
            this.cancelReceipt.Location = new System.Drawing.Point(160, 276);
            this.cancelReceipt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelReceipt.Name = "cancelReceipt";
            this.cancelReceipt.Size = new System.Drawing.Size(128, 23);
            this.cancelReceipt.TabIndex = 45;
            this.cancelReceipt.Text = "Fiş İptal";
            this.cancelReceipt.UseVisualStyleBackColor = true;
            this.cancelReceipt.Click += new System.EventHandler(this.handleCancelReceipt);
            // 
            // disconnect
            // 
            this.disconnect.Location = new System.Drawing.Point(160, 300);
            this.disconnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(128, 23);
            this.disconnect.TabIndex = 46;
            this.disconnect.Text = "Bağlantıyı Sonlandır";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_communication);
            // 
            // reConnect
            // 
            this.reConnect.Location = new System.Drawing.Point(160, 324);
            this.reConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reConnect.Name = "ReConnect";
            this.reConnect.Size = new System.Drawing.Size(128, 23);
            this.reConnect.TabIndex = 47;
            this.reConnect.Text = "Tekrar Bağlan";
            this.reConnect.UseVisualStyleBackColor = true;
            this.reConnect.Click += new System.EventHandler(this.reConnect_communication);
            // 
            // addNote
            // 
            this.addNote.Location = new System.Drawing.Point(9, 275);
            this.addNote.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addNote.Name = "addNote";
            this.addNote.Size = new System.Drawing.Size(128, 23);
            this.addNote.TabIndex = 48;
            this.addNote.Text = "Not ekle";
            this.addNote.UseVisualStyleBackColor = true;
            this.addNote.Click += new System.EventHandler(this.handleAddNote);
            // 
            // removeNote
            // 
            this.removeNote.Location = new System.Drawing.Point(9, 297);
            this.removeNote.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.removeNote.Name = "removeNote";
            this.removeNote.Size = new System.Drawing.Size(128, 23);
            this.removeNote.TabIndex = 49;
            this.removeNote.Text = "Notu kaldır";
            this.removeNote.UseVisualStyleBackColor = true;
            this.removeNote.Click += new System.EventHandler(this.handleRemoveNote);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 418);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.reConnect);
            this.Controls.Add(this.addNote);
            this.Controls.Add(this.removeNote);
            this.Controls.Add(this.cancelReceipt);
            this.Controls.Add(this.exSaleSelector);
            this.Controls.Add(this.sendJson);
            this.Controls.Add(this.exSale);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbDiscount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbPaymentPlan);
            this.Controls.Add(this.staticlb2);
            this.Controls.Add(this.lbCustomer);
            this.Controls.Add(this.staticlb1);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbItemPrice);
            this.Controls.Add(this.addItemToBasket);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbFiscal);
            this.Controls.Add(this.removeSelectedFromBasket);
            this.Controls.Add(this.addSelectedToBasket);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbSavedItems);
            this.Controls.Add(this.lbSepet);
            this.Controls.Add(this.lbBasket);
            this.Controls.Add(this.emptyBasket);
            this.Controls.Add(this.deleteLastItemInBasket);
            this.Controls.Add(this.addPearToBasket);
            this.Controls.Add(this.addWaterToBasket);
            this.Controls.Add(this.sendCard);
            this.Controls.Add(this.sendCash);
            this.Controls.Add(this.removeDiscount);
            this.Controls.Add(this.addSurcharge);
            this.Controls.Add(this.addDiscount);
            this.Controls.Add(this.removePaymentPlan);
            this.Controls.Add(this.addPaymentPlan);
            this.Controls.Add(this.removeCustomer);
            this.Controls.Add(this.addCustomer);
            this.Controls.Add(this.tbAvInfo);
            this.Controls.Add(this.sendBasket);
            this.Controls.Add(this.getFiscal);
            this.Controls.Add(this.tbConsole);


            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Text = "Hızlı Sepet";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbConsole;
        private System.Windows.Forms.Button getFiscal;
        private System.Windows.Forms.Button sendBasket;
        private System.Windows.Forms.TextBox tbAvInfo;
        private System.Windows.Forms.Button addCustomer;
        private System.Windows.Forms.Button removeCustomer;
        private System.Windows.Forms.Button removePaymentPlan;
        private System.Windows.Forms.Button addPaymentPlan;
        private System.Windows.Forms.Button addSurcharge;
        private System.Windows.Forms.Button addDiscount;
        private System.Windows.Forms.Button removeDiscount;
        private System.Windows.Forms.Button sendCash;
        private System.Windows.Forms.Button sendCard;
        private System.Windows.Forms.Button addWaterToBasket;
        private System.Windows.Forms.Button addPearToBasket;
        private System.Windows.Forms.Button deleteLastItemInBasket;
        private System.Windows.Forms.Button emptyBasket;
        private System.Windows.Forms.ListBox lbBasket;
        private System.Windows.Forms.Label lbSepet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbSavedItems;
        private System.Windows.Forms.Button addSelectedToBasket;
        private System.Windows.Forms.Button removeSelectedFromBasket;
        private System.Windows.Forms.Button addItemToBasket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbFiscal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbItemPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label lbCustomer;
        private System.Windows.Forms.Label staticlb1;
        private System.Windows.Forms.Label lbPaymentPlan;
        private System.Windows.Forms.Label staticlb2;
        private System.Windows.Forms.Label lbDiscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Button exSale;
        private System.Windows.Forms.Button sendJson;
        private System.Windows.Forms.ComboBox exSaleSelector;
        private System.Windows.Forms.Button cancelReceipt;
        private System.Windows.Forms.Button addNote;
        private System.Windows.Forms.Button removeNote;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.Button reConnect;

    }
}

