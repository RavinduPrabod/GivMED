using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Models
{
    public class DonationHeader
    {
        [Required]
        [MaxLength(50)]
        public string DonationID { get; set; }

        [Required]
        public int DonorID { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        public int HospitalID { get; set; }

        [Required]
        [MaxLength(50)]
        public string SupplyID { get; set; }

        public int DonationStatus { get; set; }

        public DateTime? DonationCreateDate { get; set; }

        public DateTime? DonationDealDate { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        [MaxLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
