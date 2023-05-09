using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Dto
{
    public class HospitalDashboardDto
    {
        public int registeredVolunteers { get; set; }

        public int CountofTotalDonation { get; set; }

        public int ContributeOrganization { get; set; }

        public int NewDonors { get; set; }

        public int RegularLevel { get; set; }

        public int UrgentLevel { get; set; }

        public int MonthlyProgress { get; set; }

        public int Urgent { get; set; }

        public int Normal { get; set; }

        public int Low { get; set; }
    }
}
