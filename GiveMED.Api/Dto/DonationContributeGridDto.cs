using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Dto
{
    public class DonationContributeGridDto
    {
        public string DonorName { get; set; }

        public string DonationID { get; set; }

        public string SupplyItemID { get; set; }

        public string SupplyItemCat { get; set; }

        public string SupplyItemName { get; set; }

        public long DonatedQty { get; set; }
    }
}
