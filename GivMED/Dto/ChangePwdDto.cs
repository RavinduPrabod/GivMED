using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GivMED.Dto
{
    public class ChangePwdDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}