using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Dto
{
    public class HomeDashLineDto
    {
        public int DonorsCount { get; set; }
        public int HospitalCount { get; set; }
        public int DonationCount { get; set; }
    }
}
