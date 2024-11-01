﻿namespace TokenDotNet
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbConsole
            // 
            this.tbConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbConsole.BackColor = System.Drawing.SystemColors.Control;
            this.tbConsole.Location = new System.Drawing.Point(722, 12);
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ReadOnly = true;
            this.tbConsole.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbConsole.Size = new System.Drawing.Size(510, 485);
            this.tbConsole.TabIndex = 0;
            this.tbConsole.Text = "";
            this.tbConsole.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.clearConsole);
            // 
            // getFiscal
            // 
            this.getFiscal.Location = new System.Drawing.Point(12, 50);
            this.getFiscal.Name = "getFiscal";
            this.getFiscal.Size = new System.Drawing.Size(171, 60);
            this.getFiscal.TabIndex = 2;
            this.getFiscal.Text = "Kayıtlı ürün ve kısımları getir";
            this.getFiscal.UseVisualStyleBackColor = true;
            this.getFiscal.Click += new System.EventHandler(this.button2_Click);
            // 
            // sendBasket
            // 
            this.sendBasket.Location = new System.Drawing.Point(12, 116);
            this.sendBasket.Name = "sendBasket";
            this.sendBasket.Size = new System.Drawing.Size(171, 28);
            this.sendBasket.TabIndex = 3;
            this.sendBasket.Text = "Sepet gönder";
            this.sendBasket.UseVisualStyleBackColor = true;
            this.sendBasket.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbAvInfo
            // 
            this.tbAvInfo.BackColor = System.Drawing.SystemColors.Info;
            this.tbAvInfo.Location = new System.Drawing.Point(509, 12);
            this.tbAvInfo.Name = "tbAvInfo";
            this.tbAvInfo.ReadOnly = true;
            this.tbAvInfo.Size = new System.Drawing.Size(174, 22);
            this.tbAvInfo.TabIndex = 4;
            this.tbAvInfo.Text = "Bağlı cihaz yok!";
            // 
            // addCustomer
            // 
            this.addCustomer.Location = new System.Drawing.Point(12, 229);
            this.addCustomer.Name = "addCustomer";
            this.addCustomer.Size = new System.Drawing.Size(171, 28);
            this.addCustomer.TabIndex = 5;
            this.addCustomer.Text = "Müşteri ekle";
            this.addCustomer.UseVisualStyleBackColor = true;
            this.addCustomer.Click += new System.EventHandler(this.addCustomer_Click);
            // 
            // removeCustomer
            // 
            this.removeCustomer.Location = new System.Drawing.Point(12, 263);
            this.removeCustomer.Name = "removeCustomer";
            this.removeCustomer.Size = new System.Drawing.Size(171, 28);
            this.removeCustomer.TabIndex = 6;
            this.removeCustomer.Text = "Müşteri kaldır";
            this.removeCustomer.UseVisualStyleBackColor = true;
            this.removeCustomer.Click += new System.EventHandler(this.removeCustomer_Click);
            // 
            // removePaymentPlan
            // 
            this.removePaymentPlan.Location = new System.Drawing.Point(12, 343);
            this.removePaymentPlan.Name = "removePaymentPlan";
            this.removePaymentPlan.Size = new System.Drawing.Size(171, 28);
            this.removePaymentPlan.TabIndex = 8;
            this.removePaymentPlan.Text = "Ödeme planı kaldır";
            this.removePaymentPlan.UseVisualStyleBackColor = true;
            this.removePaymentPlan.Click += new System.EventHandler(this.removePaymentPlan_Click);
            // 
            // addPaymentPlan
            // 
            this.addPaymentPlan.Location = new System.Drawing.Point(12, 309);
            this.addPaymentPlan.Name = "addPaymentPlan";
            this.addPaymentPlan.Size = new System.Drawing.Size(171, 28);
            this.addPaymentPlan.TabIndex = 7;
            this.addPaymentPlan.Text = "Ödeme planı ekle";
            this.addPaymentPlan.UseVisualStyleBackColor = true;
            this.addPaymentPlan.Click += new System.EventHandler(this.addPaymentPlan_Click);
            // 
            // addSurcharge
            // 
            this.addSurcharge.Location = new System.Drawing.Point(12, 429);
            this.addSurcharge.Name = "addSurcharge";
            this.addSurcharge.Size = new System.Drawing.Size(171, 28);
            this.addSurcharge.TabIndex = 10;
            this.addSurcharge.Text = "Arttırım ekle";
            this.addSurcharge.UseVisualStyleBackColor = true;
            this.addSurcharge.Click += new System.EventHandler(this.addSurcharge_Click);
            // 
            // addDiscount
            // 
            this.addDiscount.Location = new System.Drawing.Point(12, 395);
            this.addDiscount.Name = "addDiscount";
            this.addDiscount.Size = new System.Drawing.Size(171, 28);
            this.addDiscount.TabIndex = 9;
            this.addDiscount.Text = "İndirim ekle";
            this.addDiscount.UseVisualStyleBackColor = true;
            this.addDiscount.Click += new System.EventHandler(this.addDiscount_Click);
            // 
            // removeDiscount
            // 
            this.removeDiscount.Location = new System.Drawing.Point(12, 463);
            this.removeDiscount.Name = "removeDiscount";
            this.removeDiscount.Size = new System.Drawing.Size(171, 28);
            this.removeDiscount.TabIndex = 11;
            this.removeDiscount.Text = "İndirim / Arttırım kaldır";
            this.removeDiscount.UseVisualStyleBackColor = true;
            this.removeDiscount.Click += new System.EventHandler(this.removeDiscount_Click);
            // 
            // sendCash
            // 
            this.sendCash.Location = new System.Drawing.Point(12, 150);
            this.sendCash.Name = "sendCash";
            this.sendCash.Size = new System.Drawing.Size(171, 28);
            this.sendCash.TabIndex = 12;
            this.sendCash.Text = "Nakit gönder";
            this.sendCash.UseVisualStyleBackColor = true;
            this.sendCash.Click += new System.EventHandler(this.sendCash_Click);
            // 
            // sendCard
            // 
            this.sendCard.Location = new System.Drawing.Point(12, 184);
            this.sendCard.Name = "sendCard";
            this.sendCard.Size = new System.Drawing.Size(171, 28);
            this.sendCard.TabIndex = 13;
            this.sendCard.Text = "Kredi kartı gönder";
            this.sendCard.UseVisualStyleBackColor = true;
            this.sendCard.Click += new System.EventHandler(this.sendCard_Click);
            // 
            // addWaterToBasket
            // 
            this.addWaterToBasket.Location = new System.Drawing.Point(213, 347);
            this.addWaterToBasket.Name = "addWaterToBasket";
            this.addWaterToBasket.Size = new System.Drawing.Size(171, 28);
            this.addWaterToBasket.TabIndex = 14;
            this.addWaterToBasket.Text = "Su ekle";
            this.addWaterToBasket.UseVisualStyleBackColor = true;
            this.addWaterToBasket.Visible = false;
            this.addWaterToBasket.Click += new System.EventHandler(this.addAppleToBasket_Click);
            // 
            // addPearToBasket
            // 
            this.addPearToBasket.Location = new System.Drawing.Point(213, 381);
            this.addPearToBasket.Name = "addPearToBasket";
            this.addPearToBasket.Size = new System.Drawing.Size(171, 28);
            this.addPearToBasket.TabIndex = 15;
            this.addPearToBasket.Text = "Armut ekle";
            this.addPearToBasket.UseVisualStyleBackColor = true;
            this.addPearToBasket.Visible = false;
            this.addPearToBasket.Click += new System.EventHandler(this.addPearToBasket_Click);
            // 
            // deleteLastItemInBasket
            // 
            this.deleteLastItemInBasket.Location = new System.Drawing.Point(213, 427);
            this.deleteLastItemInBasket.Name = "deleteLastItemInBasket";
            this.deleteLastItemInBasket.Size = new System.Drawing.Size(171, 28);
            this.deleteLastItemInBasket.TabIndex = 16;
            this.deleteLastItemInBasket.Text = "Sepetteki son ürünü sil";
            this.deleteLastItemInBasket.UseVisualStyleBackColor = true;
            this.deleteLastItemInBasket.Click += new System.EventHandler(this.deleteLastItemInBasket_Click);
            // 
            // emptyBasket
            // 
            this.emptyBasket.Location = new System.Drawing.Point(213, 463);
            this.emptyBasket.Name = "emptyBasket";
            this.emptyBasket.Size = new System.Drawing.Size(171, 28);
            this.emptyBasket.TabIndex = 17;
            this.emptyBasket.Text = "Sepeti sıfırla";
            this.emptyBasket.UseVisualStyleBackColor = true;
            this.emptyBasket.Click += new System.EventHandler(this.emptyBasket_Click);
            // 
            // lbBasket
            // 
            this.lbBasket.FormattingEnabled = true;
            this.lbBasket.ItemHeight = 16;
            this.lbBasket.Location = new System.Drawing.Point(563, 69);
            this.lbBasket.Name = "lbBasket";
            this.lbBasket.Size = new System.Drawing.Size(120, 372);
            this.lbBasket.TabIndex = 18;
            // 
            // lbSepet
            // 
            this.lbSepet.AutoSize = true;
            this.lbSepet.Location = new System.Drawing.Point(560, 46);
            this.lbSepet.Name = "lbSepet";
            this.lbSepet.Size = new System.Drawing.Size(43, 16);
            this.lbSepet.TabIndex = 19;
            this.lbSepet.Text = "Sepet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(415, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Kayıtlı ürünler";
            // 
            // lbSavedItems
            // 
            this.lbSavedItems.FormattingEnabled = true;
            this.lbSavedItems.ItemHeight = 16;
            this.lbSavedItems.Location = new System.Drawing.Point(418, 293);
            this.lbSavedItems.Name = "lbSavedItems";
            this.lbSavedItems.Size = new System.Drawing.Size(120, 148);
            this.lbSavedItems.TabIndex = 20;
            // 
            // addSelectedToBasket
            // 
            this.addSelectedToBasket.Location = new System.Drawing.Point(418, 447);
            this.addSelectedToBasket.Name = "addSelectedToBasket";
            this.addSelectedToBasket.Size = new System.Drawing.Size(120, 50);
            this.addSelectedToBasket.TabIndex = 22;
            this.addSelectedToBasket.Text = "Seçili ürünü sepete ekle";
            this.addSelectedToBasket.UseVisualStyleBackColor = true;
            this.addSelectedToBasket.Click += new System.EventHandler(this.button1_Click);
            // 
            // removeSelectedFromBasket
            // 
            this.removeSelectedFromBasket.Location = new System.Drawing.Point(563, 447);
            this.removeSelectedFromBasket.Name = "removeSelectedFromBasket";
            this.removeSelectedFromBasket.Size = new System.Drawing.Size(120, 50);
            this.removeSelectedFromBasket.TabIndex = 23;
            this.removeSelectedFromBasket.Text = "Seçili ürünü sepetten kaldır";
            this.removeSelectedFromBasket.UseVisualStyleBackColor = true;
            this.removeSelectedFromBasket.Click += new System.EventHandler(this.removeSelectedFromBasket_Click);
            // 
            // addItemToBasket
            // 
            this.addItemToBasket.Location = new System.Drawing.Point(418, 220);
            this.addItemToBasket.Name = "addItemToBasket";
            this.addItemToBasket.Size = new System.Drawing.Size(120, 45);
            this.addItemToBasket.TabIndex = 26;
            this.addItemToBasket.Text = "Seçili kısım ile ürün sepete ekle";
            this.addItemToBasket.UseVisualStyleBackColor = true;
            this.addItemToBasket.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(415, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Kayıtlı kısımlar";
            // 
            // lbFiscal
            // 
            this.lbFiscal.FormattingEnabled = true;
            this.lbFiscal.ItemHeight = 16;
            this.lbFiscal.Location = new System.Drawing.Point(418, 66);
            this.lbFiscal.Name = "lbFiscal";
            this.lbFiscal.Size = new System.Drawing.Size(120, 148);
            this.lbFiscal.TabIndex = 24;
            this.lbFiscal.SelectedIndexChanged += new System.EventHandler(this.lbFiscal_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "Ürün fiyatı";
            // 
            // tbItemPrice
            // 
            this.tbItemPrice.Location = new System.Drawing.Point(213, 69);
            this.tbItemPrice.Name = "tbItemPrice";
            this.tbItemPrice.Size = new System.Drawing.Size(171, 22);
            this.tbItemPrice.TabIndex = 29;
            this.tbItemPrice.TextChanged += new System.EventHandler(this.tbItemPrice_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 31;
            this.label5.Text = "Sepet tutarı: ";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(296, 110);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(30, 16);
            this.lbPrice.TabIndex = 32;
            this.lbPrice.Text = "0TL";
            this.lbPrice.Click += new System.EventHandler(this.lbPrice_Click);
            // 
            // lbCustomer
            // 
            this.lbCustomer.AutoSize = true;
            this.lbCustomer.Location = new System.Drawing.Point(269, 162);
            this.lbCustomer.Name = "lbCustomer";
            this.lbCustomer.Size = new System.Drawing.Size(31, 16);
            this.lbCustomer.TabIndex = 34;
            this.lbCustomer.Text = "Yok";
            // 
            // staticlb1
            // 
            this.staticlb1.AutoSize = true;
            this.staticlb1.Location = new System.Drawing.Point(210, 162);
            this.staticlb1.Name = "staticlb1";
            this.staticlb1.Size = new System.Drawing.Size(53, 16);
            this.staticlb1.TabIndex = 33;
            this.staticlb1.Text = "Müşteri:";
            // 
            // lbPaymentPlan
            // 
            this.lbPaymentPlan.AutoSize = true;
            this.lbPaymentPlan.Location = new System.Drawing.Point(296, 187);
            this.lbPaymentPlan.Name = "lbPaymentPlan";
            this.lbPaymentPlan.Size = new System.Drawing.Size(31, 16);
            this.lbPaymentPlan.TabIndex = 36;
            this.lbPaymentPlan.Text = "Yok";
            // 
            // staticlb2
            // 
            this.staticlb2.AutoSize = true;
            this.staticlb2.Location = new System.Drawing.Point(210, 187);
            this.staticlb2.Name = "staticlb2";
            this.staticlb2.Size = new System.Drawing.Size(87, 16);
            this.staticlb2.TabIndex = 35;
            this.staticlb2.Text = "Ödeme planı:";
            // 
            // lbDiscount
            // 
            this.lbDiscount.AutoSize = true;
            this.lbDiscount.Location = new System.Drawing.Point(265, 137);
            this.lbDiscount.Name = "lbDiscount";
            this.lbDiscount.Size = new System.Drawing.Size(31, 16);
            this.lbDiscount.TabIndex = 38;
            this.lbDiscount.Text = "Yok";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 37;
            this.label6.Text = "İndirim:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TokenDotNet.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(213, 13);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(63, 16);
            this.lbVersion.TabIndex = 40;
            this.lbVersion.Text = "Version =";
            this.lbVersion.Click += new System.EventHandler(this.lbVersion_Click);
            // 
            // exSale
            // 
            this.exSale.Location = new System.Drawing.Point(213, 220);
            this.exSale.Name = "exSale";
            this.exSale.Size = new System.Drawing.Size(171, 28);
            this.exSale.TabIndex = 41;
            this.exSale.Text = "Örnek Satış Gönder";
            this.exSale.UseVisualStyleBackColor = true;
            this.exSale.Click += new System.EventHandler(this.exSale_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 515);
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
    }
}

