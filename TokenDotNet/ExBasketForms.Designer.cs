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
                DialogResult = DialogResult.OK
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    (e as FormClosingEventArgs).Cancel = true;
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

    partial class FaturaTahsilatForm : Form
    {
        public string companyName { get; private set; }
        public string date { get; private set; }
        public int taxFreeAmount { get; private set; }

        public FaturaTahsilatForm()
        {
            Label companyNameInputLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(20, 20),
                Name = "nameInputLabel",
                Size = new System.Drawing.Size(64, 16),
                Text = "Şirket Adı"
            };
            TextBox companyNameInput = new TextBox
            {
                Location = new System.Drawing.Point(20, 40),
                Width = 260,
            };
            this.Controls.Add(companyNameInputLabel);
            this.Controls.Add(companyNameInput);

            Label dateInputLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(20, 70),
                Name = "dateInputLabel",
                Size = new System.Drawing.Size(64, 16),
                Text = "Tarih"
            };
            TextBox dateInput = new TextBox
            {
                Location = new System.Drawing.Point(20, 90),
                Width = 260,
            };
            this.Controls.Add(dateInputLabel);
            this.Controls.Add(dateInput);

            Label taxFreeAmountInputLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(20, 120),
                Name = "taxFreeAmountInputLabel",
                Size = new System.Drawing.Size(64, 16),
                Text = "Tahsilat Tutarı"
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
                DialogResult = DialogResult.OK
            };
            sendPaymentButton.Click += (s, e) => {
                try
                {
                    companyName = companyNameInput.Text;
                    date = dateInput.Text;
                    int _taxFreeAmount;

                    if (string.IsNullOrWhiteSpace(companyName))
                        throw new Exception("Şirket adı boş bırakılamaz.");
                    if (string.IsNullOrWhiteSpace(date))
                        throw new Exception("Tarih boş bırakılamaz.");

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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    (e as FormClosingEventArgs).Cancel = true;
                }
            };
            this.Controls.Add(sendPaymentButton);

            this.Text = "Fatura Tahsilatı Gönder";
            this.CancelButton = cancelButton;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(300, 220);
        }
    }

    partial class CariTahsilatForm : Form
    {
        public string name { get; private set; }
        public string taxId { get; private set; }
        public string date { get; private set; }
        public int taxFreeAmount { get; private set; }

        public CariTahsilatForm()
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

            Label dateInputLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(20, 120),
                Name = "dateInputLabel",
                Size = new System.Drawing.Size(64, 16),
                Text = "Tarih"
            };
            TextBox dateInput = new TextBox
            {
                Location = new System.Drawing.Point(20, 140),
                Width = 260,
            };
            this.Controls.Add(dateInputLabel);
            this.Controls.Add(dateInput);

            Label taxFreeAmountInputLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(20, 170),
                Name = "taxFreeAmountInputLabel",
                Size = new System.Drawing.Size(64, 16),
                Text = "Tahsilat Tutarı"
            };
            TextBox taxFreeAmountInput = new TextBox
            {
                Location = new System.Drawing.Point(20, 190),
                Width = 260,
            };
            this.Controls.Add(taxFreeAmountInputLabel);
            this.Controls.Add(taxFreeAmountInput);

            Button cancelButton = new Button
            {
                Text = "İptal",
                Location = new System.Drawing.Point(80, 230),
                DialogResult = DialogResult.Cancel
            };
            this.Controls.Add(cancelButton);

            Button sendPaymentButton = new Button
            {
                Text = "Ödeme Gönder",
                Location = new System.Drawing.Point(160, 230),
                DialogResult= DialogResult.OK
            };
            sendPaymentButton.Click += (s, e) => {
                try
                {
                    name = nameInput.Text;
                    taxId = taxIdInput.Text;
                    date = dateInput.Text;
                    int _taxFreeAmount;

                    if (string.IsNullOrWhiteSpace(name))
                        throw new Exception("Şirket adı boş bırakılamaz.");
                    if (string.IsNullOrWhiteSpace(taxId))
                        throw new Exception("VKN/TCKN boş bırakılamaz.");
                    if (string.IsNullOrWhiteSpace(date))
                        throw new Exception("Tarih boş bırakılamaz.");

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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    (e as FormClosingEventArgs).Cancel = true;
                }
            };
            this.Controls.Add(sendPaymentButton);

            this.Text = "Cari Tahsilat Gönder";
            this.CancelButton = cancelButton;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(300, 270);
        }
    }

    partial class FaturaBilgiFisiForm : Form
    {
        public string serialNo { get; private set; }
        public string taxId { get; private set; }

        public FaturaBilgiFisiForm()
        {
            Label serialNoInputLabel = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(20, 20),
                Name = "serialNoInputLabel",
                Size = new System.Drawing.Size(64, 16),
                Text = "Serial No"
            };
            TextBox serialNoInput = new TextBox
            {
                Location = new System.Drawing.Point(20, 40),
                Width = 260,
            };
            this.Controls.Add(serialNoInputLabel);
            this.Controls.Add(serialNoInput);

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

            Button cancelButton = new Button
            {
                Text = "İptal",
                Location = new System.Drawing.Point(80, 130),
                DialogResult = DialogResult.Cancel
            };
            this.Controls.Add(cancelButton);

            Button sendPaymentButton = new Button
            {
                Text = "Ödeme Gönder",
                Location = new System.Drawing.Point(160, 130),
                DialogResult = DialogResult.OK
            };
            sendPaymentButton.Click += (s, e) => {
                try
                {
                    serialNo = serialNoInput.Text;
                    taxId = taxIdInput.Text;
                    int _taxFreeAmount;

                    if (string.IsNullOrWhiteSpace(serialNo))
                        throw new Exception("Seri no boş bırakılamaz.");
                    if (string.IsNullOrWhiteSpace(taxId))
                        throw new Exception("VKN/TCKN boş bırakılamaz.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    (e as FormClosingEventArgs).Cancel = true;
                }
            };
            this.Controls.Add(sendPaymentButton);

            this.Text = "Fatura Bilgi Fişi Gönder";
            this.CancelButton = cancelButton;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(300, 170);
        }
    }
}