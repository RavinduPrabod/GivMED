using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Dto
{
    public class DonationReviewFeedbackDto
    {
        public string HospitalName { get; set; }
        public string FeedDate { get; set; }
        public string DonorName { get; set; }
        public string FeedText { get; set; }
        public string ImageUrl { get; set; }
        public string SupplyCode { get; set; }

        public string DonationID { get; set; }

        public int DonorID { get; set; }

        public int HospitalID { get; set; }

        public string FeedbackText { get; set; }

        public int StartRatings { get; set; }

        public int Status { get; set; }

        public DateTime CreateDateTime { get; set; }

    }
}