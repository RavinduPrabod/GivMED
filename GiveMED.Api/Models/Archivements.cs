using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Models
{
    public class Archivements
    {
        public string UserName { get; set; }

        public int Score { get; set; }

        public int Medal { get; set; }
    }
}
