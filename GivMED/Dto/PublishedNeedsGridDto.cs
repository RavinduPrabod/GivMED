﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Dto
{
    public class PublishedNeedsGridDto
    {
        public int HospitalID { get; set; }

        public DateTime? SupplyCreateDate { get; set; }

        public DateTime? SupplyExpireDate { get; set; }

        public string SupplyNarration { get; set; }

        public int SupplyPriorityLevel { get; set; }

        public int SupplyType { get; set; }

        public int SupplyStatus { get; set; }

        public string SupplyID { get; set; }

        public int SupplyItemID { get; set; }

        public int SupplyItemCat { get; set; }

        public string SupplyItemName { get; set; }

        public long SupplyItemQty { get; set; }

    }
}