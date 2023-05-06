using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Models
{
    [Table("Complaint")]
    public class Complaint
    {
        [Required]
        [MaxLength(50)]
        public string ComplaintCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string ComplanerName { get; set; }

        [Required]
        [MaxLength(50)]
        public string ComplanerEmail { get; set; }

        [Required]
        [MaxLength(500)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(50)]
        public string NameofVictim { get; set; }

        [Required]
        [MaxLength(1000)]
        public string FullComplaint { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

    }
}
