using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Models
{
    [Table("DonationFeedback")]
    public class DonationFeedback
    {
        [Required]
        [MaxLength(50)]
        public string SupplyCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string DonationID { get; set; }

        public int DonorID { get; set; }

        [Required]
        public int HospitalID { get; set; }

        [Required]
        [MaxLength(1000)]
        public string FeedbackText { get; set; }

        [Required]
        public int StartRatings { get; set; }

        public int Status { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }
    }
}
