using GivMED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Dto
{
    public class GetDonationandSupplyDto
    {
        public SupplyRequestHeader SupplyRequestHeader { get; set; }

        public List<SupplyRequestDetails> SupplyRequestDetails { get; set; }

        public DonationHeader DonationHeader { get; set; }

        public List<DonationDetails> DonationDetails { get; set; }
    }
}