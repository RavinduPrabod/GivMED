using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Models
{
    [Table("EmailConfiguration")]
    public class EmailConfiguration
    {
        [Required]
        public int ConfigurationId { get; set; }

        public int Port { get; set; }

        [MaxLength(50)]
        public string SmtpAddress { get; set; }

        [MaxLength(50)]
        public string EmailAddress { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        [MaxLength(50)]
        public string CreatedWorkStation { get; set; }

        [MaxLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        [MaxLength(50)]
        public string ModifiedWorkStation { get; set; }
    }
}
