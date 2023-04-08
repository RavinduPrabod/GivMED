using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Models
{
    public class SupplyRequestDetails
    {
        public string SupplyID { get; set; }

        public int SupplyItemID { get; set; }

        public int SupplyItemCat { get; set; }

        public string SupplyItemName { get; set; }

        public long SupplyItemQty { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}