using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Dto
{
    public class SupplyNeedGridDto
    {
        public string SupplyID { get; set; }

        public string DonationID { get; set; }
        public int SupplyItemID { get; set; }

        public int SupplyItemCat { get; set; }

        public string ItemCatName { get; set; }

        public string SupplyItemName { get; set; }

        public long SupplyItemQty { get; set; }

        public long RequestQty { get; set; }

        public long DonatedQty { get; set; }

        public long RemainingQty { get; set; }
    }
}
