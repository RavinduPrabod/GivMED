using GiveMED.Api.Data;
using GiveMED.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private readonly DataContext _context;

        public VolunteerController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ActionName("PostVolunteerMaster")]
        public async Task<IActionResult> PostVolunteerMaster([FromBody] VolunteerMaster oList)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                LastDocSerialNo record = _context.LastDocSerialNo.Where(x => x.DocCode == "VLT").FirstOrDefault();
                record.DocCode = "VLT";
                record.LastTxnSerialNo = record.LastTxnSerialNo + 1;
                record.ModifiedBy = "admin";
                record.ModifiedDateTime = DateTime.Now;

                _context.Entry(record).State = EntityState.Modified;

                string NewDonationID = record.DocCode + record.LastTxnSerialNo.ToString("D3");
                oList.VolCode = NewDonationID;

                _context.VolunteerMaster.Add(oList);
                await _context.SaveChangesAsync();

                return Ok(oList); // Return the inserted record
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // Return the appropriate error code and message
            }

        }

        [HttpGet("{HospitalID}")]
        [ActionName("GetVolunteerMaster")]
        public List<VolunteerMaster> GetVolunteerMaster(int HospitalID)
        {

            return _context.VolunteerMaster.Where(x => x.HospitalID == HospitalID).ToList();
        }

        [HttpGet("{VolCode}")]
        [ActionName("GetVolunteerMasterbyID")]
        public VolunteerMaster GetVolunteerMasterbyID(string VolCode)
        {
            return _context.VolunteerMaster.Where(x => x.VolCode == VolCode).FirstOrDefault();
        }

        [HttpPut]
        [ActionName("PutVolunteerMaster")]
        public async Task<IActionResult> PutVolunteerMaster([FromBody] VolunteerMaster oData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //if (DocumentExists(oDocument.DocCode))
                //    ModelState.AddModelError("DocCode", "DocCode already exists");

                //if (!ModelState.IsValid)
                //    return BadRequest(ModelState);

                _context.Entry(oData).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return Ok(oData); // Return the inserted record
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // Return the appropriate error code and message
            }

        }

        [HttpDelete]
        [ActionName("DeleteVolunteerMasterbyID")]
        public async Task<IActionResult> DeleteVolunteerMasterbyID([FromBody] VolunteerMaster oList)
        {
            var volunteer = await _context.VolunteerMaster.FindAsync(oList.VolCode);
            if (volunteer == null)
            {
                return NotFound();
            }

            _context.VolunteerMaster.Remove(volunteer);
            await _context.SaveChangesAsync();

            return Ok(volunteer);
        }

    }
}
