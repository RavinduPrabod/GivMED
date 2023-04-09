using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Models
{
    public class SupplyRequestHeader
    {
        public int HospitalID { get; set; }

        public string SupplyID { get; set; }

        public DateTime? SupplyCreateDate { get; set; }

        public DateTime? SupplyExpireDate { get; set; }

        public string SupplyNarration { get; set; }

        public int SupplyPriorityLevel { get; set; }

        public int SupplyType { get; set; }

        public int SupplyStatus { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }
    }
}