using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Models
{
    [Table("VolunteerMaster")]
    public class VolunteerMaster
    {
        [Required]
        [MaxLength(50)]
        public string VolCode { get; set; }

        public int HospitalID { get; set; }

        [Required]
        [MaxLength(20)]
        public string VolNIC { get; set; }

        [Required]
        [MaxLength(100)]
        public string VolName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string Telephone { get; set; }

        [MaxLength(100)]
        public string VolEmail { get; set; }

        [MaxLength(20)]
        public string VehicleCat { get; set; }

        [MaxLength(20)]
        public string VehicleNo { get; set; }

        public int VolSkill { get; set; }

        public int Status { get; set; }

        public DateTime? CreateDateTime { get; set; }

        [MaxLength(50)]
        public string CreateUser { get; set; }

        public DateTime? ModifieDateTime { get; set; }

        [MaxLength(50)]
        public string ModifiedUser { get; set; }
    }
}
