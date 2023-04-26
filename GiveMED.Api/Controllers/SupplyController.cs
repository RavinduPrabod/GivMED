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
using OpenAI_API;
using OpenAI_API.Completions;

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
            comm.CommandText = "SELECT A.SupplyID, A.SupplyCreateDate, A.SupplyExpireDate, A.SupplyPriorityLevel, SUM(B.SupplyItemQty) AS SupplyItemQty, SUM(D.DonatedQty) as DonatedQty, A.SupplyStatus " +
                "FROM SupplyRequestHeader A " +
                "INNER JOIN SupplyRequestDetails B ON A.SupplyID = B.SupplyID " +
                "INNER JOIN HospitalMaster C ON A.HospitalID = C.HospitalID " +
                "LEFT OUTER JOIN DonationDetails D ON A.SupplyID = D.SupplyID AND B.SupplyItemCat = D.ItemCategory AND B.SupplyItemID = D.ItemID " +
                "WHERE A.SupplyStatus = 1 AND A.HospitalID = @HospitalID " +
                "GROUP BY A.SupplyID, A.SupplyCreateDate, A.SupplyExpireDate, A.SupplyPriorityLevel, A.SupplyStatus";

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
                data.SupplyStatus = Convert.IsDBNull(reader["SupplyStatus"]) ? 0 : Convert.ToInt32(reader["SupplyStatus"]);
                Records.Add(data);
            }
            conn.Close();

            foreach(var item in Records)
            {
                HospitalSupplyNeedsGridDto odata = new HospitalSupplyNeedsGridDto();
                int headercount = _context.DonationHeader.Where(z => z.SupplyID == item.SupplyID).Count();
                int feedcount = _context.DonationFeedback.Where(x => x.SupplyCode == item.SupplyID).Count();

                int result = headercount - feedcount;

                Records.ForEach(obj => {
                    if (obj.SupplyID == item.SupplyID)
                    {
                        obj.pendingcount = result;
                    }
                });
            }

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
            comm.CommandText = "SELECT A.SupplyID, A.SupplyPriorityLevel, A.SupplyCreateDate, A.SupplyExpireDate, B.SupplyItemCat, B.SupplyItemName, B.SupplyItemQty, C.HospitalName, C.HospitalID, " +
                "C.State, SUM(D.DonatedQty) as DonatedQty " +
                "FROM SupplyRequestHeader A " +
                "INNER JOIN SupplyRequestDetails B ON A.SupplyID = B.SupplyID " +
                "INNER JOIN HospitalMaster C ON A.HospitalID = C.HospitalID " +
                "LEFT OUTER JOIN DonationDetails D ON A.SupplyID = D.SupplyID AND B.SupplyItemCat = D.ItemCategory AND B.SupplyItemID = D.ItemID " +
                "WHERE A.SupplyStatus = 1 GROUP BY A.SupplyID, A.SupplyPriorityLevel, A.SupplyCreateDate, A.SupplyExpireDate, B.SupplyItemCat, B.SupplyItemName, B.SupplyItemQty, C.HospitalName, C.HospitalID, C.State;";

            var reader = comm.ExecuteReader();
            while (reader.Read())
            {
                PublishedNeedsGridDto data = new PublishedNeedsGridDto();
                data.SupplyID = Convert.IsDBNull(reader["SupplyID"]) ? "" : reader["SupplyID"].ToString();
                data.SupplyPriorityLevel = Convert.IsDBNull(reader["SupplyPriorityLevel"]) ? 0 : Convert.ToInt32(reader["SupplyPriorityLevel"]);
                data.SupplyCreateDate = Convert.IsDBNull(reader["SupplyCreateDate"]) ? DateTime.MinValue : Convert.ToDateTime(reader["SupplyCreateDate"]);
                data.SupplyExpireDate = Convert.IsDBNull(reader["SupplyExpireDate"]) ? DateTime.MinValue : Convert.ToDateTime(reader["SupplyExpireDate"]);
                data.SupplyItemCat = Convert.IsDBNull(reader["SupplyItemCat"]) ? 0 : Convert.ToInt32(reader["SupplyItemCat"]);
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
            comm.CommandText = "SELECT A.SupplyItemID, A.SupplyItemCat, A.SupplyItemName, A.SupplyItemQty, B.ItemCatName, SUM(C.DonatedQty) as DonatedQty " +
                "FROM SupplyRequestDetails A " +
                "INNER JOIN ItemCatMaster B ON A.SupplyItemCat = B.ItemCatID " +
                "LEFT OUTER JOIN DonationDetails C ON A.SupplyID = C.SupplyID AND A.SupplyItemCat = C.ItemCategory AND A.SupplyItemID = C.ItemID WHERE A.SupplyID = @SupplyID " +
                "GROUP BY A.SupplyItemID, A.SupplyItemCat, A.SupplyItemName, A.SupplyItemQty, B.ItemCatName;";

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

        [HttpGet("{DonationID}")]
        [ActionName("GetDonationNeedGridForID")]
        public IEnumerable<SupplyNeedGridDto> GetDonationNeedGridForID(string DonationID)
        {
            List<SupplyNeedGridDto> Records = new List<SupplyNeedGridDto>();

            var id = new SqlParameter("DonationID", DonationID);
            var conn = _context.Database.GetDbConnection();
            conn.Open();
            var comm = conn.CreateCommand();
            comm.CommandText = "SELECT A.SupplyItemID, A.SupplyItemCat, A.SupplyItemName, A.SupplyItemQty, B.ItemCatName, SUM(C.DonatedQty) as DonatedQty " +
                "FROM SupplyRequestDetails A " +
                "INNER JOIN ItemCatMaster B ON A.SupplyItemCat = B.ItemCatID " +
                "LEFT OUTER JOIN DonationDetails C ON A.SupplyID = C.SupplyID AND A.SupplyItemCat = C.ItemCategory AND A.SupplyItemID = C.ItemID WHERE C.DonationID = @DonationID " +
                "GROUP BY A.SupplyItemID, A.SupplyItemCat, A.SupplyItemName, A.SupplyItemQty, B.ItemCatName;";

            comm.Parameters.Add(id);
            var reader = comm.ExecuteReader();
            while (reader.Read())
            {
                SupplyNeedGridDto data = new SupplyNeedGridDto();
                data.SupplyItemID = Convert.IsDBNull(reader["SupplyItemID"]) ? 0 : Convert.ToInt32(reader["SupplyItemID"]);
                data.SupplyItemCat = Convert.IsDBNull(reader["SupplyItemCat"]) ? 0 : Convert.ToInt32(reader["SupplyItemCat"]);
                data.SupplyItemName = Convert.IsDBNull(reader["SupplyItemName"]) ? "" : reader["SupplyItemName"].ToString();
                data.RequestQty = Convert.IsDBNull(reader["SupplyItemQty"]) ? 0 : Convert.ToInt64(reader["SupplyItemQty"]);
                data.DonatedQty = Convert.IsDBNull(reader["DonatedQty"]) ? 0 : Convert.ToInt64(reader["DonatedQty"]);
                data.ItemCatName = Convert.IsDBNull(reader["ItemCatName"]) ? "" : reader["ItemCatName"].ToString();
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
            HospitalMaster odata = new HospitalMaster();
            odata = _context.HospitalMaster.Where(x => x.HospitalID == HospitalID).FirstOrDefault();

            return odata;
        }

        [HttpGet("{DonationID}")]
        [ActionName("GetFeedBackForID")]
        public DonationFeedback GetFeedBackForID(string DonationID)
        {
            DonationFeedback odata = new DonationFeedback();
            odata = _context.DonationFeedback.Where(x => x.DonationID == DonationID).FirstOrDefault();

            return odata;
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

        [HttpGet("{HospitalID}")]
        [ActionName("GetTemplate")]
        public List<ComboDTO> GetTemplate(int HospitalID)
        {
            List<ManageTemplate> result = new List<ManageTemplate>();
            List<ComboDTO> comlist = new List<ComboDTO>();

            result = _context.ManageTemplate.Where(x=>x.HospitalID == HospitalID).ToList();

            foreach (var item in result)
            {
                ComboDTO odata = new ComboDTO();
                odata.DataValueField = item.TemplateID.ToString();
                odata.DataTextField = "Draft" + item.TemplateID.ToString();
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

                return Ok(NewSupplyID); // Return the inserted record
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // Return the appropriate error code and message
            }
        }

        [HttpPost]
        [ActionName("PostTemplate")]
        public async Task<IActionResult> PostTemplate([FromBody] ManageTemplate result)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                int NewTempID = _context.ManageTemplate.Where(x => x.HospitalID == result.HospitalID).Select(x=>x.TemplateID).Max();
                NewTempID = NewTempID + 1;

                result.TemplateID = NewTempID;
                _context.ManageTemplate.Add(result);

                await _context.SaveChangesAsync();

                return Ok(NewTempID); // Return the inserted record


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

                if (result.DonationVolunteer.Count > 0)
                {
                    result.DonationVolunteer.ForEach(x => x.DonationCode = NewDonationID);
                    result.DonationVolunteer.ForEach(x => x.HospitalID = result.DonationHeader.HospitalID);
                    _context.DonationVolunteer.AddRange(result.DonationVolunteer);
                }

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


        [HttpPost]
        [ActionName("UseChatGPT")]
        public async Task<IActionResult> UseChatGPT([FromBody] string query)
        {
            string OutPutResult = "";
            var openai = new OpenAIAPI("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");
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = "What is the " + query + "?";
            completionRequest.Prompt += "\nAverage Price of LKR " + query + " is:";
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;
            completionRequest.MaxTokens = 2048; // Limit the response length to 2048 tokens

            var completions = await openai.Completions.CreateCompletionAsync(completionRequest);

            // Get the first completion as the result
            var completion = completions.Completions[0];
            OutPutResult = completion.Text;

            return Ok(OutPutResult);
        }

        [HttpPost]
        [ActionName("UseChatGPTFeedBack")]
        public async Task<IActionResult> UseChatGPTFeedBack([FromBody] string query)
        {
            string OutPutResult = "";
            var openai = new OpenAIAPI("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");
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = query;
            completionRequest.MaxTokens = 2048; // Limit the response length to 2048 tokens

            var completions = await openai.Completions.CreateCompletionAsync(completionRequest);

            // Get the first completion as the result
            var completion = completions.Completions[0];
            OutPutResult = completion.Text;

            return Ok(OutPutResult);
        }


        //donationactivuty

        [HttpGet("{UserName}")]
        [ActionName("GetDonationHeaderDetails")]
        public IEnumerable<DonationActivityDto> GetDonationHeaderDetails(string UserName)
        {
            List<DonationActivityDto> Records = new List<DonationActivityDto>();

            var id = new SqlParameter("UserName", UserName);
            var conn = _context.Database.GetDbConnection();
            conn.Open();
            var comm = conn.CreateCommand();
            comm.CommandText = "SELECT A.DonationID, A.SupplyID, A.DonationCreateDate, A.HospitalID, B.HospitalName, B.Email, C.[Status] " +
                "FROM DonationHeader A " +
                "INNER JOIN HospitalMaster B ON A.HospitalID = B.HospitalID " +
                "LEFT OUTER JOIN DonationFeedback C On A.DonationID = C.DonationID " +
                "WHERE A.UserName = @UserName";

            comm.Parameters.Add(id);
            var reader = comm.ExecuteReader();
            while (reader.Read())
            {
                DonationActivityDto data = new DonationActivityDto();
                data.SupplyID = Convert.IsDBNull(reader["SupplyID"]) ? "" : reader["SupplyID"].ToString();
                data.DonationID = Convert.IsDBNull(reader["DonationID"]) ? "" : reader["DonationID"].ToString();
                data.DonationCreateDate = Convert.IsDBNull(reader["DonationCreateDate"]) ? DateTime.MinValue : Convert.ToDateTime(reader["DonationCreateDate"]);
                data.HospitalID = Convert.IsDBNull(reader["HospitalID"]) ? 0 : Convert.ToInt32(reader["HospitalID"]);
                data.HospitalName = Convert.IsDBNull(reader["HospitalName"]) ? "" : reader["HospitalName"].ToString();
                data.Email = Convert.IsDBNull(reader["Email"]) ? "" : reader["Email"].ToString();
                data.Status = Convert.IsDBNull(reader["Status"]) ? 0 : Convert.ToInt32(reader["Status"]);
                Records.Add(data);
            }
            conn.Close();

            return Records;
        }

        //[HttpGet("{UserName}")]
        //[ActionName("GetArchivementsData")]
        //public IEnumerable<ArchivementsDto> GetArchivementsData(string UserName)
        //{
        //    List<ArchivementsDto> Records = new List<ArchivementsDto>();

        //    var id = new SqlParameter("UserName", UserName);
        //    var conn = _context.Database.GetDbConnection();
        //    conn.Open();
        //    var comm = conn.CreateCommand();
        //    comm.CommandText = "SELECT A.DonationID, A.DonationCreateDate, A.HospitalID, B.HospitalName, B.Email " +
        //        "FROM DonationHeader A " +
        //        "INNER JOIN HospitalMaster B ON A.HospitalID = B.HospitalID " +
        //        "WHERE A.UserName = @UserName";

        //    comm.Parameters.Add(id);
        //    var reader = comm.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        ArchivementsDto data = new ArchivementsDto();
        //        data.us = Convert.IsDBNull(reader["DonationID"]) ? "" : reader["DonationID"].ToString();
        //        data.DonationCreateDate = Convert.IsDBNull(reader["DonationCreateDate"]) ? DateTime.MinValue : Convert.ToDateTime(reader["DonationCreateDate"]);
        //        data.HospitalID = Convert.IsDBNull(reader["HospitalID"]) ? 0 : Convert.ToInt32(reader["HospitalID"]);
        //        data.HospitalName = Convert.IsDBNull(reader["HospitalName"]) ? "" : reader["HospitalName"].ToString();
        //        data.Email = Convert.IsDBNull(reader["Email"]) ? "" : reader["Email"].ToString();
        //        Records.Add(data);
        //    }
        //    conn.Close();

        //    return Records;
        //}

        [HttpGet("{HospitalID}")]
        [ActionName("GetDonationContributeGridData")]
        public IEnumerable<HospitalSupplyNeedsGridDto> GetDonationContributeGridData(int HospitalID)
        {
            List<HospitalSupplyNeedsGridDto> Records = new List<HospitalSupplyNeedsGridDto>();

            var id = new SqlParameter("HospitalID", HospitalID);
            var conn = _context.Database.GetDbConnection();
            conn.Open();
            var comm = conn.CreateCommand();
            comm.CommandText = "SELECT A.SupplyID,  A.SupplyCreateDate, A.SupplyExpireDate, A.SupplyPriorityLevel,  B.SupplyItemQty, " +
                "SUM(D.DonatedQty) as DonatedQty , C.DonorID " +
                "FROM SupplyRequestHeader A " +
                "INNER JOIN SupplyRequestDetails B ON A.SupplyID = B.SupplyID " +
                "INNER JOIN DonationHeader C ON A.SupplyID = C.SupplyID " +
                "LEFT OUTER JOIN DonationDetails D ON A.SupplyID = D.SupplyID AND B.SupplyItemCat = D.ItemCategory AND B.SupplyItemID = D.ItemID " +
                "WHERE A.HospitalID = @HospitalID AND DonatedQty > 0 " +
                "GROUP BY A.SupplyID, C.DonorID, A.SupplyCreateDate, A.SupplyExpireDate, A.SupplyPriorityLevel, B.SupplyItemQty";

            comm.Parameters.Add(id);
            var reader = comm.ExecuteReader();
            while (reader.Read())
            {
                HospitalSupplyNeedsGridDto data = new HospitalSupplyNeedsGridDto();
                data.SupplyID = Convert.IsDBNull(reader["SupplyID"]) ? "" : reader["SupplyID"].ToString();
                data.SupplyCreateDate = Convert.IsDBNull(reader["SupplyCreateDate"]) ? DateTime.MinValue : Convert.ToDateTime(reader["SupplyCreateDate"]);
                data.SupplyExpireDate = Convert.IsDBNull(reader["SupplyExpireDate"]) ? DateTime.MinValue : Convert.ToDateTime(reader["SupplyExpireDate"]);
                data.SupplyPriorityLevel = Convert.IsDBNull(reader["SupplyPriorityLevel"]) ? 0 : Convert.ToInt32(reader["SupplyPriorityLevel"]);
                data.RequestQty = Convert.IsDBNull(reader["SupplyItemQty"]) ? 0 : Convert.ToInt64(reader["SupplyItemQty"]);
                data.DonatedQty = Convert.IsDBNull(reader["DonatedQty"]) ? 0 : Convert.ToInt64(reader["DonatedQty"]);
                data.DonorCount = Convert.IsDBNull(reader["DonorID"]) ? 0 : Convert.ToInt32(reader["DonorID"]);
                Records.Add(data);
            }
            conn.Close();

            return Records;
        }

        [HttpGet("{SupplyID}")]
        [ActionName("GetDonorsForID")]
        public IEnumerable<DonationContributeGridDto> GetDonorsForID(string SupplyID)
        {
            List<DonationContributeGridDto> Records = new List<DonationContributeGridDto>();

            var id = new SqlParameter("SupplyID", SupplyID);
            var conn = _context.Database.GetDbConnection();
            conn.Open();
            var comm = conn.CreateCommand();
            comm.CommandText = "SELECT " +
                "CASE " +
                "WHEN C.DonorType = 1 THEN CONCAT(C.DonorFirstName,' ', C.DonorLastName) " +
                "WHEN C.DonorType = 2 THEN C.DonorFirstName END As DonorName,C.UserName,C.DonorID, A.DonationID, D.ItemCatName, E.ItemName, B.DonatedQty, F.[Status] " +
                "FROM DonationHeader A " +
                "INNER JOIN DonorMaster C ON A.DonorID = C.DonorID " +
                "INNER JOIN DonationDetails B ON B.DonationID = A.DonationID " +
                "INNER JOIN ItemCatMaster D ON B.ItemCategory = D.ItemCatID " +
                "INNER JOIN ItemMaster E ON B.ItemID = E.ItemID " +
                "LEFT OUTER JOIN DonationFeedback F On A.DonationID = F.DonationID " +
                "WHERE A.SupplyID = @SupplyID";

            comm.Parameters.Add(id);
            var reader = comm.ExecuteReader();
            while (reader.Read())
            {
                DonationContributeGridDto data = new DonationContributeGridDto();
                data.DonorName = Convert.IsDBNull(reader["DonorName"]) ? "" : reader["DonorName"].ToString();
                data.UserName = Convert.IsDBNull(reader["UserName"]) ? "" : reader["UserName"].ToString();
                data.DonorID = Convert.IsDBNull(reader["DonorID"]) ? 0 : Convert.ToInt32(reader["DonorID"]);
                data.DonationID = Convert.IsDBNull(reader["DonationID"]) ? "" : reader["DonationID"].ToString();
                data.SupplyItemCat = Convert.IsDBNull(reader["ItemCatName"]) ? "" : reader["ItemCatName"].ToString();
                data.SupplyItemName = Convert.IsDBNull(reader["ItemName"]) ? "" : reader["ItemName"].ToString();
                data.DonatedQty = Convert.IsDBNull(reader["DonatedQty"]) ? 0 : Convert.ToInt64(reader["DonatedQty"]);
                data.Status = Convert.IsDBNull(reader["Status"]) ? 0 : Convert.ToInt32(reader["Status"]);
                Records.Add(data);
            }
            conn.Close();

            return Records;
        }

        [HttpGet("{SupplyID}")]
        [ActionName("GetFeedBackForSupplyID")]
        public IEnumerable<DonationReviewFeedbackDto> GetFeedBackForSupplyID(string SupplyID)
        {
            List<DonationReviewFeedbackDto> Records = new List<DonationReviewFeedbackDto>();

            var id = new SqlParameter("SupplyID", SupplyID);
            var conn = _context.Database.GetDbConnection();
            conn.Open();
            var comm = conn.CreateCommand();
            comm.CommandText = "SELECT CASE " +
                "WHEN C.DonorType = 1 THEN CONCAT(C.DonorFirstName,' ', C.DonorLastName) " +
                "WHEN C.DonorType = 2 THEN C.DonorFirstName END As DonorName, B.HospitalName, A.CreatedDateTime, A.FeedbackText, A.StartRatings, D.[FileName] " +
                "FROM DonationFeedback A " +
                "INNER JOIN HospitalMaster B ON A.HospitalID = B.HospitalID " +
                "INNER JOIN DonorMaster C ON A.DonorID = C.DonorID " +
                "LEFT OUTER JOIN ProfileImages D ON C.UserName = D.UserName WHERE A.SupplyCode = @SupplyID";

            comm.Parameters.Add(id);
            var reader = comm.ExecuteReader();
            while (reader.Read())
            {
                DonationReviewFeedbackDto data = new DonationReviewFeedbackDto();
                data.DonorName = Convert.IsDBNull(reader["DonorName"]) ? "" : reader["DonorName"].ToString();
                data.HospitalName = Convert.IsDBNull(reader["HospitalName"]) ? "" : reader["HospitalName"].ToString();
                data.CreateDateTime = Convert.IsDBNull(reader["CreatedDateTime"]) ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedDateTime"]);
                data.FeedbackText = Convert.IsDBNull(reader["FeedbackText"]) ? "" : reader["FeedbackText"].ToString();
                data.StartRatings = Convert.IsDBNull(reader["StartRatings"]) ? 0 : Convert.ToInt32(reader["StartRatings"]);
                data.ImageUrl = Convert.IsDBNull(reader["FileName"]) ? "" : reader["FileName"].ToString();
                Records.Add(data);
            }
            conn.Close();

            return Records;
        }


        [HttpPost]
        [ActionName("PostFeedBack")]
        public async Task<IActionResult> PostFeedBack([FromBody] DonationFeedback result)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.DonationFeedback.Add(result);

                await _context.SaveChangesAsync();

                return Ok(); // Return the inserted record


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); // Return the appropriate error code and message
            }
        }

        [HttpGet("{UserName}")]
        [ActionName("GetAll")]
        public bool GetIsDonorAvailability(string UserName)
        {
            bool isAvailable = false;
            isAvailable = _context.DonorMaster.Where(x => x.UserName == UserName).Any();

            return isAvailable;
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> Delete([FromBody] DonationActivityDto oList)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var donationHeader = _context.DonationHeader.FirstOrDefault(x => x.DonationID == oList.DonationID.ToString());
                if (donationHeader != null)
                {
                    _context.DonationHeader.Remove(donationHeader);
                }

                var donationDetails = _context.DonationDetails.Where(x => x.DonationID == oList.DonationID.ToString());
                if (donationDetails != null)
                {
                    _context.DonationDetails.RemoveRange(donationDetails);
                }

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while deleting the donation.");
            }

        }
    }
}
