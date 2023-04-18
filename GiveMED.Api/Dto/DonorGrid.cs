using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Dto
{
    public class DonorGrid
    {
        public string DonorName { get; set; }

        public List<DonationContributeGridDto> DonationContributeGridDto { get; set; }
    }
}
