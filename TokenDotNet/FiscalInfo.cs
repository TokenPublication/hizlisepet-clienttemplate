using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenDotNet
{
    internal class FiscalInfo
    {
        public int businessMode { get; set; }
        public int pluCount { get; set; }
        public List<Plus> plus { get; set; }
        public object receiptLimit { get; set; }
        public int sectionCount { get; set; }
        public List<Section> sections { get; set; }
    }

    internal class Plus
    {
        public string barcode { get; set; }
        public string name { get; set; }
        public int pluNo { get; set; }
        public int price { get; set; }
        public int sectionNo { get; set; }
        public int taxPercent { get; set; }
        public int type { get; set; }
        public string unit { get; set; }
        public int vatID { get; set; }
    }

    internal class Section
    {
        public int limit { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int sectionNo { get; set; }
        public int taxPercent { get; set; }
        public int type { get; set; }
    }
}
