using GivMED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Dto
{
    public class SupplyNeedsDto
    {
        public SupplyRequestHeader SupplyRequestHeader { get; set; }

        public List<SupplyRequestDetails> SupplyRequestDetails { get; set; }
    }
}