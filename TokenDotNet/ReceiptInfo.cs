using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenDotNet
{
    internal class PaymentItemReceipt
    {
        public decimal amount { get; set; }
        public int BatchNo { get; set; }
        public int currencyId { get; set; }
        public string description { get; set; }
        public int operatorId { get; set; }
        public int status { get; set; }
        public int TxnNo { get; set; }
        public int type { get; set; }
    }

    internal class ReceiptInfo
    {
        public string basketID { get; set; }
        public int documentType { get; set; }
        public string InstanceIdentifier { get; set; }
        public string invoiceID { get; set; }
        public string message { get; set; }
        public int paymentCount { get; set; }
        public List<PaymentItemReceipt> paymentItems { get; set; }
        public int receiptNo { get; set; }
        public string UUID { get; set; }
        public int zNo { get; set; }
        public int status { get; set; }
    }
}
