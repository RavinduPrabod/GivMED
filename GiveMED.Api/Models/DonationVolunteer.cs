using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Models
{
    [Table("DonationVolunteer")]
    public class DonationVolunteer
    {
        [Required]
        [MaxLength(50)]
        public string DonationCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string SupplyCode { get; set; }

        [Required]
        public int HospitalID { get; set; }

        [Required]
        public int DonorID { get; set; }

        [Required]
        [MaxLength(50)]
        public string VolunteerCode { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        [MaxLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
