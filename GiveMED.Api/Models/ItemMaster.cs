using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Models
{
    [Table("ItemMaster")]
    public class ItemMaster
    {
        [Required]
        public int ItemID { get; set; }

        [Required]
        public int ItemCatID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ItemName { get; set; }

        [MaxLength(200)]
        public string ItemDescription { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        [MaxLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
