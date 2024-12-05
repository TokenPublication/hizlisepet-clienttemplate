using System;
using System.Windows.Forms;

namespace TokenDotNet
{
    partial class AvansForm: Form
    {
        public string name { get; private set; }
        public string taxId { get; private set; }
        public int taxFreeAmount { get; private set; }

        public AvansForm()
        {
            Label nameInputLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(20, 20),
                Name = "nameInputLabel",
                Size = new System.Drawing.Size(64, 16),
                Text = "Ad ve Soyad"
            };
            TextBox nameInput = new TextBox
            {
                Location = new System.Drawing.Point(20, 40),
                Width = 260,
            };
            this.Controls.Add(nameInputLabel);
            this.Controls.Add(nameInput);

            Label taxIdInputLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(20, 70),
                Name = "taxIdInputLabel",
                Size = new System.Drawing.Size(64, 16),
                Text = "VKN/TCKN"
            };
            TextBox taxIdInput = new TextBox
            {
                Location = new System.Drawing.Point(20, 90),
                Width = 260,
            };
            this.Controls.Add(taxIdInputLabel);
            this.Controls.Add(taxIdInput);

            Label taxFreeAmountInputLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(20, 120),
                Name = "taxFreeAmountInputLabel",
                Size = new System.Drawing.Size(64, 16),
                Text = "Avans Tutarı"
            };
            TextBox taxFreeAmountInput = new TextBox
            {
                Location = new System.Drawing.Point(20, 140),
                Width = 260,
            };
            this.Controls.Add(taxFreeAmountInputLabel);
            this.Controls.Add(taxFreeAmountInput);

            Button cancelButton = new Button
            {
                Text = "İptal",
                Location = new System.Drawing.Point(80, 180),
                DialogResult = DialogResult.Cancel
            };
            this.Controls.Add(cancelButton);

            Button sendPaymentButton = new Button
            {
                Text = "Ödeme Gönder",
                Location = new System.Drawing.Point(160, 180),
            };
            sendPaymentButton.Click += (s, e) => {
                try
                {
                    name = nameInput.Text;
                    taxId = taxIdInput.Text;
                    int _taxFreeAmount;

                    if (string.IsNullOrWhiteSpace(name))
                        throw new Exception("Ad ve Soyad boş bırakılamaz.");
                    if (string.IsNullOrWhiteSpace(taxId))
                        throw new Exception("VKN/TCKN boş bırakılamaz.");

                    if (!int.TryParse(taxFreeAmountInput.Text, out _taxFreeAmount))
                    {
                        throw new Exception("Avans miktarı sayısal bir değer olmalıdır.");
                    }
                    else if (_taxFreeAmount < 0)
                    {
                        throw new Exception("Avans miktarı negatif olamaz.");
                    }
                    else
                    {
                        taxFreeAmount = _taxFreeAmount;
                    }
                    (s as Button).DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    (s as Button).DialogResult = DialogResult.None;
                }
            };
            this.Controls.Add(sendPaymentButton);

            this.Text = "Avans Gönder";
            this.CancelButton = cancelButton;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(300, 220);
        }
    }
}