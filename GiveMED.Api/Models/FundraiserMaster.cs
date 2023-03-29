using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Models
{
    [Table("FundraiserMaster")]
    public class FundraiserMaster
    {
        [Required]
        [MaxLength(50)]
        public string FundraiserID { get; set; }

        [Required]
        [MaxLength(200)]
        public string FundraiserName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string Telephone { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public string State { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required]
        [MaxLength(50)]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string ContactPerson { get; set; }

        [Required]
        [MaxLength(50)]
        public string Designation { get; set; }

        [Required]
        public int OrganizationType { get; set; }

        [Required]
        public int RegType { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public DateTime? CreateDateTime { get; set; }

        [MaxLength(50)]
        public string CreateUser { get; set; }

        public DateTime? ModifieDateTime { get; set; }

        [MaxLength(50)]
        public string ModifiedUser { get; set; }
    }
}
