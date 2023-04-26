using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Dto
{
    public class DonationActivityDto
    {
        public string DonationID { get; set; }

        public string SupplyID { get; set; }

        public DateTime DonationCreateDate { get; set; }

        public int HospitalID { get; set; }

        public string HospitalName { get; set; }

        public string Email { get; set; }

        public int Status { get; set; }

        public string SearchIndex => $"{DonationID} {"-"} {HospitalName} {"-"} {Email}";
    }
}