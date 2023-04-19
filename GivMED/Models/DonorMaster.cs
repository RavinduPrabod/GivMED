using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Models
{
    public class DonorMaster
    {
        public int DonorID { get; set; }
        public string UserName { get; set; }

        public string DonorFirstName { get; set; }

        public string DonorLastName { get; set; }
        public string Address { get; set; }

        public string Telephone { get; set; }

        public string City { get; set; }

        public string State { get; set; }


        public string Country { get; set; }

        public string ZipCode { get; set; }

        public string Email { get; set; }

        public string ContactPerson { get; set; }


        public string Designation { get; set; }

        public int OrgType { get; set; }

        public int DonorType { get; set; }

        public string Description { get; set; }

        public int PublicStatus { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}