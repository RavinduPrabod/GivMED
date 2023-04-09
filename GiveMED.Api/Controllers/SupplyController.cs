using GiveMED.Api.Data;
using GiveMED.Api.Dto;
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
    public class SupplyController : ControllerBase
    {
        private readonly DataContext _context;
        public SupplyController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ActionName("GetItemCat")]
        public List<ComboDTO> GetItemCat()
        {
            List<ItemCatMaster> result = new List<ItemCatMaster>();
            List<ComboDTO> comlist = new List<ComboDTO>();

            result = _context.ItemCatMaster.ToList();

            foreach(var item in result)
            {
                ComboDTO odata = new ComboDTO();
                odata.DataValueField = item.ItemCatID.ToString();
                odata.DataTextField = item.ItemCatName;
                comlist.Add(odata);
            }
            return comlist;
        }

        [HttpGet]
        [ActionName("GetAllItem")]
        public List<ItemMaster> GetAllItem()
        {
            return _context.ItemMaster.ToList();
        }

        [HttpGet]
        [ActionName("GetAllItems")]
        public List<ComboDTO> GetAllItems()
        {
            List<ItemMaster> result = new List<ItemMaster>();
            List<ComboDTO> comlist = new List<ComboDTO>();

            result = _context.ItemMaster.ToList();

            foreach (var item in result)
            {
                ComboDTO odata = new ComboDTO();
                odata.DataValueField = item.ItemID.ToString();
                odata.DataTextField = item.ItemName;
                comlist.Add(odata);
            }
            return comlist;
        }

        [HttpPost]
        [ActionName("PostSupplyNeed")]
        public async Task<IActionResult> PostSupplyNeed([FromBody] SupplyNeedsDto result)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                LastDocSerialNo record = _context.LastDocSerialNo.Where(x => x.DocCode == "SPN").FirstOrDefault();
                record.DocCode = "SPN";
                record.LastTxnSerialNo = record.LastTxnSerialNo + 1;
                record.ModifiedBy = "admin";
                record.ModifiedDateTime = DateTime.Now;

                _context.Entry(record).State = EntityState.Modified;

                result.SupplyRequestHeader.HospitalID = _context.HospitalMaster.Where(x => x.UserName == result.UserName).FirstOrDefault().HospitalID;
                string NewSupplyID = record.DocCode + record.LastTxnSerialNo.ToString("D3");
                result.SupplyRequestHeader.SupplyID = NewSupplyID;
                result.SupplyRequestDetails.ForEach(x => x.SupplyID = NewSupplyID);

                _context.SupplyRequestHeader.Add(result.SupplyRequestHeader);
                _context.SupplyRequestDetails.AddRange(result.SupplyRequestDetails);

                await _context.SaveChangesAsync();

                return Ok(result); // Return the inserted record
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // Return the appropriate error code and message
            }
        }
    }
}
