using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Dto
{
    public class VwAnnualreport
    {
        public int HospitalID { get; set; }
        public string SupplyID { get; set; }
        public string HospitalName { get; set; }
        public string City { get; set; }
        public string ItemCatName { get; set; }
        public int SupplyItemQty { get; set; }
        public int SupplyItemID { get; set; }
        public int SupplyItemCat { get; set; }
        public string SupplyItemName { get; set; }
        public DateTime SupplyCreateDate { get; set; }
        public DateTime SupplyExpireDate { get; set; }
        public int SupplyPriorityLevel { get; set; }
        public string SupplyPriorityLevelText { get; set; }

    }
}