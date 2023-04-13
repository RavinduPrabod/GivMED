using GiveMED.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Dto
{
    public class GetDonationandSupplyDto
    {
        public List<SupplyRequestDetails> SupplyRequestHeader { get; set; }

        public List<SupplyRequestDetails> SupplyRequestDetails { get; set; }

        public List<SupplyRequestDetails> DonationHeader { get; set; }

        public List<DonationDetails> DonationDetails { get; set; }
    }
}
