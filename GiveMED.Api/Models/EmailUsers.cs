﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Models
{
    [Table("EmailUsers")]
    public class EmailUsers
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public int Publicity { get; set; }

        [Required]
        public int EmailNotification { get; set; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }


        [MaxLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}
