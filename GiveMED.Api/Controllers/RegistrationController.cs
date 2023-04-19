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
    public class RegistrationController : Controller
    {
        private readonly DataContext _context;

        public RegistrationController(DataContext context)
        {
            _context = context;
        }

        #region Donor
        
        [HttpPost]
        [ActionName("PostProfileImage")]
        public async Task<IActionResult> PostProfileImage([FromBody] ProfileImages oList)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                //if (!ModelState.IsValid)
                //    return BadRequest(ModelState);

                bool ifhave = _context.ProfileImages.Where(x => x.UserName == oList.UserName).Any();

                if(ifhave)
                {
                    var profileImages = _context.ProfileImages.Where(x => x.UserName == oList.UserName).DefaultIfEmpty();
                    foreach (var image in profileImages)
                    {
                        _context.ProfileImages.Remove(image);
                    }
                    _context.SaveChanges();
                    _context.ProfileImages.Add(oList);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.ProfileImages.Add(oList);
                    await _context.SaveChangesAsync();
                }
               
                return Ok(oList); // Return the inserted record
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // Return the appropriate error code and message
            }
            
        }

        [HttpGet("{UserName}")]
        [ActionName("GetImage")]
        public ProfileImages GetImage(string UserName)
        {

            return (from A in _context.ProfileImages
                    where A.UserName == UserName
                    select new ProfileImages
                    {
                        UserName = A.UserName,
                        FileName = A.FileName
                    }).FirstOrDefault();
        }

        [HttpPost]
        [ActionName("PostDonor")]
        public async Task<IActionResult> PostDonor([FromBody] DonorMaster oData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                LastSerialNo record = _context.LastSerialNo.Where(x => x.DonorType == oData.DonorType).FirstOrDefault();
                record.DonorType = oData.DonorType;
                record.LastDonorID = record.LastDonorID + 1;
                record.ModifiedBy = "admin";
                record.ModifiedDateTime = DateTime.Now;

                _context.Entry(record).State = EntityState.Modified;

                oData.DonorID = record.LastDonorID;

                _context.DonorMaster.Add(oData);
                await _context.SaveChangesAsync();

                return Ok(oData); // Return the inserted record
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // Return the appropriate error code and message
            }
        }


        [HttpPut]
        [ActionName("PutDonor")]
        public async Task<IActionResult> PutDonor([FromBody] DonorMaster oData)
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

        [HttpGet("{UserName}")]
        [ActionName("CheckDonorMaster")]
        public bool CheckDonorMaster(string UserName)
        {
            return _context.DonorMaster.Where(x => x.UserName == UserName).Any();
        }

        [HttpGet("{UserName}")]
        [ActionName("GetDonorMaster")]
        public DonorMaster GetDonorMaster(string UserName)
        {
            return _context.DonorMaster.Where(x => x.UserName == UserName).FirstOrDefault();
        }

        [HttpGet("{UserName}")]
        [ActionName("GetHospitalMaster")]
        public HospitalMaster GetHospitalMaster(string UserName)
        {
            return _context.HospitalMaster.Where(x => x.UserName == UserName).FirstOrDefault();
        }
        #endregion Donor

        #region Hospital
        private bool HospitalExists(string name)
        {
            return _context.HospitalMaster.Any(e => e.HospitalName == name);
        }

        [HttpPost]
        [ActionName("PostHospital")]
        public async Task<IActionResult> PostHospital([FromBody] HospitalMaster oData)
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
                LastSerialNo record = new LastSerialNo();
                record = _context.LastSerialNo.Where(x => x.DonorType == 3).FirstOrDefault();
                record.DonorType = 3;
                record.LastDonorID = record.LastDonorID + 1;
                record.ModifiedBy = "admin";
                record.ModifiedDateTime = DateTime.Now;

                _context.Entry(record).State = EntityState.Modified;

                oData.HospitalID = record.LastDonorID;

                _context.HospitalMaster.Add(oData);
                await _context.SaveChangesAsync();

                return Ok(oData); // Return the inserted record
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // Return the appropriate error code and message
            }
        }

        [HttpPut]
        [ActionName("PutHospital")]
        public async Task<IActionResult> PutHospital([FromBody] HospitalMaster oData)
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

        [HttpGet("{UserName}")]
        [ActionName("CheckHospitalMasterAvailability")]
        public bool CheckHospitalMasterAvailability(string UserName)
        {
            return _context.HospitalMaster.Where(x => x.UserName == UserName).Any();
        }

        [HttpGet("{UserName}")]
        [ActionName("CheckDonorMasterAvailability")]
        public bool CheckDonorMasterAvailability(string UserName)
        {
            return _context.DonorMaster.Where(x => x.UserName == UserName).Any();
        }

        #endregion Hospital

    }
}
