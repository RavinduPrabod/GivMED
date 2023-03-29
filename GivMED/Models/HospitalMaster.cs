using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Models
{
    public class HospitalMaster
    {
        public string HospitalID { get; set; }

        public string HospitalName { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public string Email { get; set; }
 
        public string ContactPerson { get; set; }

        public string Designation { get; set; }

        public int TypeofHosptal { get; set; }

        public string RegistrationNo { get; set; }

        public int YearEstablish { get; set; }

        public int NoOfBeds { get; set; }
         
        public string WebURL { get; set; }

        public DateTime? CreateDateTime { get; set; }
         
        public string CreateUser { get; set; }

        public DateTime? ModifieDateTime { get; set; }
    
        public string ModifiedUser { get; set; }
    }
}