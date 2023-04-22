using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Dto
{
    public class TopTrendingDonorDto
    {
        public int DonorID { get; set; }

        public string DonorName { get; set; }

        public string DonationID { get; set; }

        public string SupplyID { get; set; }

        public string HospitalName { get; set; }

        public string ImgURL { get; set; }

        public int DonationCredit { get; set; }

        public decimal DonationPrecentatge { get; set; }

        public DateTime? LastActivityDate { get; set; }

        public string Lastprogram1 { get; set; }

        public string Lastprogram2 { get; set; }

        public DateTime? CreatedDateTime { get; set; }
    }
}
