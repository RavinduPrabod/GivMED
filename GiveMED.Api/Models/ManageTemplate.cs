using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Models
{
    public class ManageTemplate
    {
        [Required]
        public int HospitalID { get; set; }

        [Required]
        public int TemplateID { get; set; }

        [MaxLength(1000)]
        [Required]
        public string TemplateText { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        [MaxLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
