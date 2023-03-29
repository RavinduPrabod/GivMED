using GiveMED.Api.Data;
using GiveMED.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegistrationController : Controller
    {
        private readonly DataContext _context;

        public RegistrationController(DataContext context)
        {
            _context = context;
        }

        private bool HospitalExists(string name)
        {
            return _context.HospitalMaster.Any(e => e.HospitalName == name);
        }

        [HttpPost]
        [ActionName("PostHospital")]
        public async Task<IActionResult> PostHospital([FromBody] HospitalMaster oData)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //if (DocumentExists(oDocument.DocCode))
            //    ModelState.AddModelError("DocCode", "DocCode already exists");

            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            _context.HospitalMaster.Add(oData);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
