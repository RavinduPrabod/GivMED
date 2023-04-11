using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Models
{
    [Table("SupplyRequestHeader")]
    public class SupplyRequestHeader
    {
        [Required]
        public int HospitalID { get; set; }

        [Required]
        [MaxLength(50)]
        public string SupplyID { get; set; }

        public DateTime? SupplyCreateDate { get; set; }

        public DateTime? SupplyExpireDate { get; set; }

        [MaxLength(200)]
        public string SupplyNarration { get; set; }

        [Required]
        public int SupplyPriorityLevel { get; set; }

        [Required]
        public int SupplyType { get; set; }

        [Required]
        public int SupplyStatus { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        [MaxLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
