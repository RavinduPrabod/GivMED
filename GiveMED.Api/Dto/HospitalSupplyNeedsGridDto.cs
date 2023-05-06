using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Dto
{
    public class HospitalSupplyNeedsGridDto
    {
        public int HospitalID { get; set; }

        public string SupplyID { get; set; }

        public DateTime? SupplyCreateDate { get; set; }

        public DateTime? SupplyExpireDate { get; set; }

        public string SupplyNarration { get; set; }

        public int SupplyPriorityLevel { get; set; }

        public int SupplyType { get; set; }

        public int SupplyStatus { get; set; }

        public long RequestQty { get; set; }

        public long DonatedQty { get; set; }

        public long RemainingQty { get; set; }

        public decimal Proceprecent { get; set; }

        public int DonorCount { get; set; }

        public int pendingcount { get; set; }

        public int completecount { get; set; }

        public int processcount { get; set; }

        public int Cancelcount { get; set; }
    }
}
