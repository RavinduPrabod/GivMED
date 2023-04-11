using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Models
{
    public class DonationDetails
    {
        [Required]
        [MaxLength(50)]
        public string DonationID { get; set; }

        [Required]
        [MaxLength(50)]
        public string SupplyID { get; set; }

        [Required]
        public int ItemID { get; set; }

        [Required]
        public int ItemCategory { get; set; }

        [Required]
        [MaxLength(100)]
        public string ItemName { get; set; }

        public long RequestQty { get; set; }

        public long DonatedQty { get; set; }

        public int DonationStatus { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        [MaxLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
