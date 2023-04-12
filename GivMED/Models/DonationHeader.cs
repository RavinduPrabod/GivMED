using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Models
{
    public class DonationHeader
    {
        public string DonationID { get; set; }

        public int DonorID { get; set; }

        public string UserName { get; set; }

        public int HospitalID { get; set; }

        public string SupplyID { get; set; }

        public int DonationStatus { get; set; }

        public DateTime? DonationCreateDate { get; set; }

        public DateTime? DonationDealDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}