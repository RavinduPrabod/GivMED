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

        public int SupplyPriorityLevel { get; set; }

        public int RequestQty { get; set; }

        public int DonatedQty { get; set; }

        public int DonorCount { get; set; }

        public string City { get; set; }

        public DateTime? CreatedDateTime { get; set; }
    }
}
