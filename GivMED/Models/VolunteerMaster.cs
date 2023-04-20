using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Models
{
    public class VolunteerMaster
    {
        public string VolCode { get; set; }

        public int HospitalID { get; set; }

        public string VolNIC { get; set; }

        public string VolName { get; set; }

        public string Address { get; set; }


        public string Telephone { get; set; }


        public string VolEmail { get; set; }


        public int VehicleCat { get; set; }


        public string VehicleNo { get; set; }

        public int VolSkill { get; set; }

        public int Status { get; set; }

        public DateTime? CreateDateTime { get; set; }


        public string CreateUser { get; set; }

        public DateTime? ModifieDateTime { get; set; }


        public string ModifiedUser { get; set; }
    }
}