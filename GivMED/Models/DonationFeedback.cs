using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Models
{
    public class DonationFeedback
    {
        public string SupplyCode { get; set; }

        public string DonationID { get; set; }

        public int DonorID { get; set; }

        public int HospitalID { get; set; }

        public string FeedbackText { get; set; }


        public int StartRatings { get; set; }

        public int Status { get; set; }


        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }
    }
}