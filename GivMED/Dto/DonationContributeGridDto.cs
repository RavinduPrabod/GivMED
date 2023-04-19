using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Dto
{
    public class DonationContributeGridDto
    {
        public string DonorName { get; set; }

        public string UserName { get; set; }

        public int DonorID { get; set; }

        public string DonationID { get; set; }

        public string SupplyItemID { get; set; }

        public string SupplyItemCat { get; set; }

        public string SupplyItemName { get; set; }

        public long DonatedQty { get; set; }

        public string DonatedQtytext { get; set; }

        public int Status { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}