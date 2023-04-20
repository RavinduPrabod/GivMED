using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Models
{
    public class DonationVolunteer
    {
        public string DonationCode { get; set; }

        public string SupplyCode { get; set; }

        public int HospitalID { get; set; }


        public int DonorID { get; set; }

        public string VolunteerCode { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}