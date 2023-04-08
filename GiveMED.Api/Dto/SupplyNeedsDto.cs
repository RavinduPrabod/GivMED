using GiveMED.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Dto
{
    public class SupplyNeedsDto
    {
        public SupplyRequestHeader SupplyRequestHeader { get; set; }

        public List<SupplyRequestDetails> SupplyRequestDetails { get; set; }
    }
}
