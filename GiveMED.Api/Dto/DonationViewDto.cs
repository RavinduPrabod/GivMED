using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Dto
{
    public class DonationViewDto
    {
        public int HospitalID { get; set; }
        public string HospitalName { get; set; }
        public string DonationID { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string DonorFirstName { get; set; }
        public string DonorLastName { get; set; }
        public long DonatedQty { get; set; }
        public DateTime? DonationCreateDate { get; set; }
    }
}
