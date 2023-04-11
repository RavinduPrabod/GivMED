using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Dto
{
    public class PublishedNeedsGridDto
    {
        public int HospitalID { get; set; }

        public string HospitalName { get; set; }

        public string State { get; set; }

        public DateTime? SupplyCreateDate { get; set; }

        public DateTime? SupplyExpireDate { get; set; }

        public string SupplyNarration { get; set; }

        public int SupplyPriorityLevel { get; set; }

        public int SupplyType { get; set; }

        public int SupplyStatus { get; set; }

        public string SupplyID { get; set; }

        public int SupplyItemID { get; set; }

        public int SupplyItemCat { get; set; }

        public string SupplyItemName { get; set; }

        public long SupplyItemQty { get; set; }

        public long RequestQty { get; set; }

        public long DonatedQty { get; set; }
    }
}
