using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Models
{
    [Table("SupplyRequestDetails")]
    public class SupplyRequestDetails
    {
        [Required]
        public string SupplyID { get; set; }

        [Required]
        [MaxLength(50)]
        public int SupplyItemID { get; set; }

        [Required]
        public int SupplyItemCat { get; set; }

        [Required]
        [MaxLength(100)]
        public string SupplyItemName { get; set; }

        [Required]
        public long SupplyItemQty { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        [MaxLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
