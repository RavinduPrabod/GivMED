using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Dto
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


        public string DonorNameT1 { get; set; }
        public string ImgURLT1 { get; set; }
        public int DonationCreditT1 { get; set; }
        public DateTime? LastActivityDateT1 { get; set; }
        public string Lastprogram1T1 { get; set; }
        public string Lastprogram2T1 { get; set; }

        public string DonorNameT2 { get; set; }
        public string ImgURLT2 { get; set; }
        public int DonationCreditT2 { get; set; }
        public DateTime? LastActivityDateT2 { get; set; }
        public string Lastprogram1T2 { get; set; }
        public string Lastprogram2T2 { get; set; }

        public string DonorNameT3 { get; set; }
        public string ImgURLT3 { get; set; }
        public int DonationCreditT3 { get; set; }
        public DateTime? LastActivityDateT3 { get; set; }
        public string Lastprogram1T3 { get; set; }
        public string Lastprogram2T3 { get; set; }
    }
}