using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Dto
{
    public class DeliveryDataDto
    {
        public string VehicleNo { get; set; }

        public string DriverName { get; set; }

        public string Telephone { get; set; }

        public DateTime? Date { get; set; }

        public string Time { get; set; }

        public string email { get; set; }

        public string donationid { get; set; }

        public string supplyid { get; set; }

        public int Status { get; set; }
    }
}