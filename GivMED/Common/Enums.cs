﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Common
{
    public class Enums
    {
        public enum DataEntryMode
        {
            Add = 1,
            View = 2,
            Edit = 3
        }

        public enum StatusCode
        {
            Success = 200,
            Created = 201,
            NoContent = 204,
            BadRequest = 400,
            Unauthorized = 401
        }

        public enum RegType
        {
            Individual = 1,
            Organization = 2,
            Hospital = 3
        }

        public enum UserStatus
        {
            Active = 1,
            Inactive = 2
        }

        public enum typeofhospital
        {
            General_hospital = 1,
            Specialty_hospital = 2,
            Teaching_hospital = 3,
            Children_hospital = 4,
            Rehabilitation_hospital = 4,
            Rural_hospital = 5,
            Community_hospital = 6,
            Academic_medical_cente = 7
        }

        //TransactionCode
                            //SupplyNeed - SPN
                            //Donation - DTN
    }
}