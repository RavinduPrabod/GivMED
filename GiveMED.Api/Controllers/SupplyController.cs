using GiveMED.Api.Data;
using GiveMED.Api.Dto;
using GiveMED.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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

        [HttpGet("{HospitalID}")]
        [ActionName("GetSupplyNeedHeaderlist")]
        public List<HospitalSupplyNeedsGridDto> GetSupplyNeedHeaderlist(int HospitalID)
        {
            List<HospitalSupplyNeedsGridDto> Records = new List<HospitalSupplyNeedsGridDto>();

            var id = new SqlParameter("HospitalID", HospitalID);
            var conn = _context.Database.GetDbConnection();
            conn.Open();
            var comm = conn.CreateCommand();
            comm.CommandText = "SELECT A.SupplyID, A.SupplyCreateDate, A.SupplyExpireDate, A.SupplyPriorityLevel, " +
                "B.SupplyItemQty, C.DonatedQty " +
                "FROM SupplyRequestHeader A " +
                "LEFT OUTER JOIN SupplyRequestDetails B ON A.SupplyID = B.SupplyID " +
                "LEFT OUTER JOIN DonationDetails C ON B.SupplyID = C.SupplyID AND B.SupplyItemID = C.ItemID AND B.SupplyItemCat = C.ItemCategory " +
                "WHERE A.HospitalID = @HospitalID";

            comm.Parameters.Add(id);
            var reader = comm.ExecuteReader();
            while (reader.Read())
            {
                HospitalSupplyNeedsGridDto data = new HospitalSupplyNeedsGridDto();
                data.SupplyID = Convert.IsDBNull(reader["SupplyID"]) ? "" : reader["SupplyID"].ToString();
                data.SupplyPriorityLevel = Convert.IsDBNull(reader["SupplyPriorityLevel"]) ? 0 : Convert.ToInt32(reader["SupplyPriorityLevel"]);
                data.SupplyCreateDate = Convert.IsDBNull(reader["SupplyCreateDate"]) ? DateTime.MinValue : Convert.ToDateTime(reader["SupplyCreateDate"]);
                data.SupplyExpireDate = Convert.IsDBNull(reader["SupplyExpireDate"]) ? DateTime.MinValue : Convert.ToDateTime(reader["SupplyExpireDate"]);
                data.RequestQty = Convert.IsDBNull(reader["SupplyItemQty"]) ? 0 : Convert.ToInt64(reader["SupplyItemQty"]);
                data.DonatedQty = Convert.IsDBNull(reader["DonatedQty"]) ? 0 : Convert.ToInt64(reader["DonatedQty"]);
                Records.Add(data);
            }
            conn.Close();

            return Records;
        }

        [HttpGet]
        [ActionName("GetSupplyNeedHeaderWithDetails")]
        public IEnumerable<PublishedNeedsGridDto> GetSupplyNeedHeaderWithDetails()
        {
            List<PublishedNeedsGridDto> Records = new List<PublishedNeedsGridDto>();

            var conn = _context.Database.GetDbConnection();
            conn.Open();
            var comm = conn.CreateCommand();
            comm.CommandText = "SELECT " +
                "A.SupplyID, A.SupplyPriorityLevel, A.SupplyCreateDate,A.SupplyExpireDate, " +
                "B.SupplyItemName, B.SupplyItemQty, " +
                "C.HospitalName, C.HospitalID, C.State, " +
                "D.DonatedQty " +
                "FROM SupplyRequestHeader A " +
                "INNER JOIN SupplyRequestDetails B ON A.SupplyID = B.SupplyID " +
                "INNER JOIN HospitalMaster C ON A.HospitalID = C.HospitalID " +
                "LEFT OUTER JOIN DonationDetails D ON A.SupplyID = D.SupplyID AND B.SupplyItemCat = D.ItemCategory AND B.SupplyItemID = D.ItemID " +
                "WHERE A.SupplyStatus = 1";

            var reader = comm.ExecuteReader();
            while (reader.Read())
            {
                PublishedNeedsGridDto data = new PublishedNeedsGridDto();
                data.SupplyID = Convert.IsDBNull(reader["SupplyID"]) ? "" : reader["SupplyID"].ToString();
                data.SupplyPriorityLevel = Convert.IsDBNull(reader["SupplyPriorityLevel"]) ? 0 : Convert.ToInt32(reader["SupplyPriorityLevel"]);
                data.SupplyCreateDate = Convert.IsDBNull(reader["SupplyCreateDate"]) ? DateTime.MinValue : Convert.ToDateTime(reader["SupplyCreateDate"]);
                data.SupplyExpireDate = Convert.IsDBNull(reader["SupplyExpireDate"]) ? DateTime.MinValue : Convert.ToDateTime(reader["SupplyExpireDate"]);
                data.SupplyItemName = Convert.IsDBNull(reader["SupplyItemName"]) ? "" : reader["SupplyItemName"].ToString();
                data.HospitalName = Convert.IsDBNull(reader["HospitalName"]) ? "" : reader["HospitalName"].ToString();
                data.HospitalID = Convert.IsDBNull(reader["HospitalID"]) ? 0 : Convert.ToInt32(reader["HospitalID"]);
                data.State = Convert.IsDBNull(reader["State"]) ? "" : reader["State"].ToString();
                data.DonatedQty = Convert.IsDBNull(reader["DonatedQty"]) ? 0 : Convert.ToInt64(reader["DonatedQty"]);
                data.SupplyItemQty = Convert.IsDBNull(reader["SupplyItemQty"]) ? 0 : Convert.ToInt64(reader["SupplyItemQty"]);
                Records.Add(data);
            }
            conn.Close();

            return Records;
        }

        [HttpGet("{SupplyID}")]
        [ActionName("GetSupplyNeedGridForID")]
        public IEnumerable<SupplyNeedGridDto> GetSupplyNeedGridForID(string SupplyID)
        {
            List<SupplyNeedGridDto> Records = new List<SupplyNeedGridDto>();

            var id = new SqlParameter("SupplyID", SupplyID);
            var conn = _context.Database.GetDbConnection();
            conn.Open();
            var comm = conn.CreateCommand();
            comm.CommandText = "SELECT " +
                "A.SupplyItemID, A.SupplyItemCat, A.SupplyItemName, A.SupplyItemQty, " +
                "B.ItemCatName, " +
                "C.DonatedQty " +
                "FROM " +
                "SupplyRequestDetails A " +
                "INNER JOIN ItemCatMaster B ON A.SupplyItemCat = B.ItemCatID " +
                "LEFT OUTER JOIN DonationDetails C ON A.SupplyID = C.SupplyID AND A.SupplyItemCat = C.ItemCategory AND A.SupplyItemID = C.ItemID " +
                "WHERE A.SupplyID = @SupplyID";

            comm.Parameters.Add(id);
            var reader = comm.ExecuteReader();
            while (reader.Read())
            {
                SupplyNeedGridDto data = new SupplyNeedGridDto();
                data.SupplyItemID = Convert.IsDBNull(reader["SupplyItemID"]) ? 0 : Convert.ToInt32(reader["SupplyItemID"]);
                data.SupplyItemCat = Convert.IsDBNull(reader["SupplyItemCat"]) ? 0 : Convert.ToInt32(reader["SupplyItemCat"]);
                data.SupplyItemName = Convert.IsDBNull(reader["SupplyItemName"]) ? "" : reader["SupplyItemName"].ToString();
                data.SupplyItemQty = Convert.IsDBNull(reader["SupplyItemQty"]) ? 0 : Convert.ToInt64(reader["SupplyItemQty"]);
                data.DonatedQty = Convert.IsDBNull(reader["DonatedQty"]) ? 0 : Convert.ToInt64(reader["DonatedQty"]);
                data.ItemCatName = Convert.IsDBNull(reader["ItemCatName"]) ? "" : reader["ItemCatName"].ToString();
                data.RemainingQty = data.SupplyItemQty - data.DonatedQty;
                Records.Add(data);
            }
            conn.Close();

            return Records;
        }


        [HttpGet("{SupplyID}")]
        [ActionName("GetSupplyNeedsForID")]
        public SupplyNeedsDto GetSupplyNeedsForID(string SupplyID)
        {
            SupplyNeedsDto oSupplyNeedsDto = new SupplyNeedsDto();
            oSupplyNeedsDto.SupplyRequestHeader = _context.SupplyRequestHeader.Where(x => x.SupplyID == SupplyID).FirstOrDefault();
            oSupplyNeedsDto.SupplyRequestDetails = _context.SupplyRequestDetails.Where(x => x.SupplyID == SupplyID).ToList();
            oSupplyNeedsDto.ManageTemplate = _context.ManageTemplate.Where(x => x.HospitalID == oSupplyNeedsDto.SupplyRequestHeader.HospitalID).FirstOrDefault();

            return oSupplyNeedsDto;
        }

        [HttpGet("{HospitalID}")]
        [ActionName("GetHospitalMasterForID")]
        public HospitalMaster GetHospitalMasterForID(int HospitalID)
        {
            HospitalMaster oHospitalMaster = new HospitalMaster();
            oHospitalMaster = _context.HospitalMaster.Where(x => x.HospitalID == HospitalID).FirstOrDefault();

            return oHospitalMaster;
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

        [HttpPost]
        [ActionName("PostDonation")]
        public async Task<IActionResult> PostDonation([FromBody] PublishedNeedsPostDto result)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                LastDocSerialNo record = _context.LastDocSerialNo.Where(x => x.DocCode == "DTN").FirstOrDefault();
                record.DocCode = "DTN";
                record.LastTxnSerialNo = record.LastTxnSerialNo + 1;
                record.ModifiedBy = "admin";
                record.ModifiedDateTime = DateTime.Now;

                _context.Entry(record).State = EntityState.Modified;

                result.DonationHeader.HospitalID = _context.SupplyRequestHeader.Where(x => x.SupplyID == result.DonationHeader.SupplyID).FirstOrDefault().HospitalID;
                string NewDonationID = record.DocCode + record.LastTxnSerialNo.ToString("D3");
                result.DonationHeader.DonationID = NewDonationID;
                result.DonationDetails.ForEach(x => x.DonationID = NewDonationID);

                _context.DonationHeader.Add(result.DonationHeader);
                _context.DonationDetails.AddRange(result.DonationDetails);

                await _context.SaveChangesAsync();

                return Ok(NewDonationID); // Return the inserted record
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // Return the appropriate error code and message
            }
        }
    }
}
