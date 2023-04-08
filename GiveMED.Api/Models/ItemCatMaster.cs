using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Models
{
    [Table("ItemCatMaster")]
    public class ItemCatMaster
    {
        [Required]
        public int ItemCatID { get; set; }

        [Required]
        [MaxLength(50)]
        public string ItemCatName { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }
    }
}
