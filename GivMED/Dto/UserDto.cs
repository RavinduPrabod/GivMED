using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Dto
{
    public class UserDto
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Type { get; set; }

        public int Status { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public int NoOfAttempts { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public string CreatedWorkStation { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public string ModifiedWorkStation { get; set; }

        public string UserEmail { get; set; }
    }
}