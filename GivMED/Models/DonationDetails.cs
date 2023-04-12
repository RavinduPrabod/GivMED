using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Models
{
    public class DonationDetails
    {
        public string DonationID { get; set; }

        public string SupplyID { get; set; }

        public int ItemID { get; set; }

        public int ItemCategory { get; set; }

        public string ItemName { get; set; }

        public long RequestQty { get; set; }

        public long DonatedQty { get; set; }

        public int DonationStatus { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}