using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenDotNet
{
    public class Basket
    {
        public string basketID { get; set; } = "93ced0be-99f5-4e42-b0ca-bc781c778d69";
        public bool createInvoice { get; set; }
        public int documentType { get; set; }
        public int taxFreeAmount { get; set; }
        public bool isVoid { get; set; }
        public List<Item> items = new List<Item>();
        public CustomerInfo customerInfo { get; set; }
        public List<PaymentItem> paymentItems = new List<PaymentItem>();
        public Adjust adjust { get; set; }
        public InfoReceiptInfo infoReceiptInfo { get; set; }
        public bool isWayBill { get; set; }
        public string note { get; set; }

        public int calculatePrice()
        {
            // Calculate the sum of item prices in the basket
            int basketTotal = items.Sum(item => item.price);

            // Calculate the total price based on adjust
            int totalPrice = adjust == null
                ? basketTotal
                : adjust.discountOrSurcharge == 0
                    ? (adjust.type == 0
                        ? basketTotal - adjust.value
                        : (basketTotal * (100 - adjust.value/100)) / 100)
                    : (adjust.type == 0
                        ? basketTotal + adjust.value
                        : (basketTotal * (100 + adjust.value/100)) / 100);

            return totalPrice;
        }
    }

    public class Item
    {
        public string barcode { get; set; }
        public string name { get; set; }
        public int pluNo { get; set; }
        public int price { get; set; }  // Price is in minor units (e.g., cents)
        public int sectionNo { get; set; }
        public int taxPercent { get; set; }
        public int type { get; set; }
        public string unit { get; set; }
        public int vatID { get; set; }
        public int limit { get; set; }
        public int quantity { get; set; }  // Quantity is in minor units
        public int paymentType { get; set; }

        public override string ToString()
        {
            return $"{name} - {((float)price / 100).ToString()}TL";
        }
    }

    public class CustomerInfo
    {
        public string buildingName { get; set; }
        public string buildingNumber { get; set; }
        public string cityName { get; set; }
        public string citySubdivisonName { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public bool isLock { get; set; }
        public string name { get; set; }
        public string postalZone { get; set; }
        public string region { get; set; }
        public string room { get; set; }
        public string street { get; set; }
        public string taxID { get; set; }
        public string taxScheme { get; set; }
        public string telefax { get; set; }
        public string telephone { get; set; }
    }

    public class PaymentItem
    {
        public string description { get; set; } = "NAKIT";
        public int amount { get; set; }  // Amount is in minor units
        public int type { get; set; }
        public int taxRate { get; set; }
    }

    public class Adjust
    {
        public string description { get; set; }
        public int discountOrSurcharge { get; set; }
        public int type { get; set; }
        public int value { get; set; }  // Value is in minor units
    }

}
