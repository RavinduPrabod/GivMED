using GiveMED.Api.Data;
using GiveMED.Api.Dto;
using GiveMED.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OpenAI_API;
using OpenAI_API.Completions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiveMED.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ActionName("GetTopRateDonors")]
        public IEnumerable<TopTrendingDonorDto> GetTopRateDonors()
        {
            List<TopTrendingDonorDto> Records = new List<TopTrendingDonorDto>();

            var conn = _context.Database.GetDbConnection();
            conn.Open();
            var comm = conn.CreateCommand();
            comm.CommandText = "SELECT CASE " +
                "WHEN B.DonorType = 1 THEN CONCAT(B.DonorFirstName,' ', B.DonorLastName) WHEN B.DonorType = 2 THEN B.DonorFirstName END As DonorName, " +
                "A.DonationID, A.DonorID, C.FileName, A.CreatedDateTime, A.SupplyID, E.HospitalName " +
                "FROM DonationHeader A " +
                "INNER JOIN DonorMaster B ON A.DonorID =B.DonorID " +
                "LEFT OUTER JOIN ProfileImages C ON B.UserName = C.UserName " +
                "INNER JOIN SupplyRequestHeader D ON A.SupplyID = D.SupplyID " +
                "INNER JOIN HospitalMaster E ON D.HospitalID = E.HospitalID " +
                "INNER JOIN EmailUsers F ON A.UserName = F.UserName WHERE F.Publicity = 1";
            var reader = comm.ExecuteReader();
            while (reader.Read())
            {
                TopTrendingDonorDto data = new TopTrendingDonorDto();
                data.DonorName = Convert.IsDBNull(reader["DonorName"]) ? "" : reader["DonorName"].ToString();
                data.DonorID = Convert.IsDBNull(reader["DonorID"]) ? 0 : Convert.ToInt32(reader["DonorID"]);
                data.DonationID = Convert.IsDBNull(reader["DonationID"]) ? "" : reader["DonationID"].ToString();
                data.ImgURL = Convert.IsDBNull(reader["FileName"]) ? "user.png" : reader["FileName"].ToString();
                data.CreatedDateTime = Convert.IsDBNull(reader["CreatedDateTime"]) ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedDateTime"]);
                data.SupplyID = Convert.IsDBNull(reader["SupplyID"]) ? "" : reader["SupplyID"].ToString();
                data.HospitalName = Convert.IsDBNull(reader["HospitalName"]) ? "" : reader["HospitalName"].ToString();
                Records.Add(data);
            }
            conn.Close();

            return Records;
        }

        [HttpGet]
        [ActionName("GetTopTrendingDonations")]
        public IEnumerable<TopTrendingDonorDto> GetTopTrendingDonations()
        {
            List<TopTrendingDonorDto> Records = new List<TopTrendingDonorDto>();

            var conn = _context.Database.GetDbConnection();
            conn.Open();
            var comm = conn.CreateCommand();
            comm.CommandText = "SELECT C.SupplyID, A.DonationID, C.SupplyPriorityLevel, B.RequestQty, B.DonatedQty, A.DonorID, D.HospitalName, D.City, DonorCounts.DonorCount " +
                "FROM DonationHeader A " +
                "INNER JOIN DonationDetails B ON A.DonationID = B.DonationID " +
                "LEFT OUTER JOIN SupplyRequestHeader C ON A.SupplyID = C.SupplyID " +
                "INNER JOIN HospitalMaster D ON C.HospitalID = D.HospitalID " +
                "INNER JOIN ( SELECT SupplyID, COUNT(DISTINCT DonorID) AS DonorCount " +
                "FROM DonationHeader GROUP BY SupplyID ) DonorCounts ON C.SupplyID = DonorCounts.SupplyID " +
                "WHERE C.SupplyStatus != 4 ";
            var reader = comm.ExecuteReader();
            while (reader.Read())
            {
                TopTrendingDonorDto data = new TopTrendingDonorDto();
                data.SupplyID = Convert.IsDBNull(reader["SupplyID"]) ? "" : reader["SupplyID"].ToString();
                data.DonationID = Convert.IsDBNull(reader["DonationID"]) ? "" : reader["DonationID"].ToString();
                data.SupplyPriorityLevel = Convert.IsDBNull(reader["SupplyPriorityLevel"]) ? 0 : Convert.ToInt32(reader["SupplyPriorityLevel"]);
                data.RequestQty = Convert.IsDBNull(reader["RequestQty"]) ? 0 : Convert.ToInt32(reader["RequestQty"]);
                data.DonatedQty = Convert.IsDBNull(reader["DonatedQty"]) ? 0 : Convert.ToInt32(reader["DonatedQty"]);
                data.DonorID = Convert.IsDBNull(reader["DonorID"]) ? 0 : Convert.ToInt32(reader["DonorID"]);
                data.HospitalName = Convert.IsDBNull(reader["HospitalName"]) ? "" : reader["HospitalName"].ToString();
                data.City = Convert.IsDBNull(reader["City"]) ? "" : reader["City"].ToString();
                data.DonorCount = Convert.IsDBNull(reader["DonorCount"]) ? 0 : Convert.ToInt32(reader["DonorCount"]);
                Records.Add(data);
            }
            conn.Close();

            return Records;
        }

        [HttpGet]
        [ActionName("GetHomeDashTopLineData")]

        public HomeDashLineDto GetHospitalMasterForID()
        {
            HomeDashLineDto odata = new HomeDashLineDto();
            odata.DonorsCount = _context.DonorMaster.Count();
            odata.HospitalCount = _context.HospitalMaster.Count();
            odata.DonationCount = _context.SupplyRequestHeader.Count();

            return odata;
        }

        [HttpGet]
        [ActionName("GetDonationView")]
        public IEnumerable<DonationViewDto> GetDonationView()
        {
            List<DonationViewDto> Records = new List<DonationViewDto>();

            var conn = _context.Database.GetDbConnection();
            conn.Open();
            var comm = conn.CreateCommand();
            comm.CommandText = "SELECT * FROM [DonationView]";
            var reader = comm.ExecuteReader();
            while (reader.Read())
            {
                DonationViewDto data = new DonationViewDto();
                data.HospitalID = Convert.IsDBNull(reader["HospitalID"]) ? 0 : Convert.ToInt32(reader["HospitalID"]);
                data.HospitalName = Convert.IsDBNull(reader["HospitalName"]) ? "" : reader["HospitalName"].ToString();
                data.DonationID = Convert.IsDBNull(reader["DonationID"]) ? "" : reader["DonationID"].ToString();
                data.ItemID = Convert.IsDBNull(reader["ItemID"]) ? 0 : Convert.ToInt32(reader["ItemID"]);
                data.ItemName = Convert.IsDBNull(reader["ItemName"]) ? "" : reader["ItemName"].ToString();
                data.DonorFirstName = Convert.IsDBNull(reader["DonorFirstName"]) ? "" : reader["DonorFirstName"].ToString();
                data.DonatedQty = Convert.IsDBNull(reader["DonatedQty"]) ? 0 : Convert.ToInt64(reader["DonatedQty"]);
                data.DonationCreateDate = Convert.IsDBNull(reader["DonationCreateDate"]) ? DateTime.MinValue : Convert.ToDateTime(reader["DonationCreateDate"]);
                Records.Add(data);
            }
            conn.Close();

            return Records;
        }

        [HttpPost]
        [ActionName("UseChatGPTreport")]
        public async Task<IActionResult> UseChatGPTreport([FromBody] string query)
        {
            string OutPutResult = "";
            var openai = new OpenAIAPI("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");
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = "What are these supplies total Estimate Price of LKR " + query + "? (provide me numbers only)";
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;
            completionRequest.MaxTokens = 2048; // Limit the response length to 2048 tokens

            var completions = await openai.Completions.CreateCompletionAsync(completionRequest);

            // Get the first completion as the result
            var completion = completions.Completions[0];
            OutPutResult = completion.Text;

            return Ok(OutPutResult);
        }

        [HttpGet()]
        [ActionName("GetAllDonors")]
        public List<DonorMaster> GetAllDonors()
        {
            return _context.DonorMaster.ToList();
        }

        [HttpGet()]
        [ActionName("GetAllHospitals")]
        public List<HospitalMaster> GetAllHospitals()
        {
            return _context.HospitalMaster.ToList();
        }

        [HttpGet()]
        [ActionName("GetAllRequestHeader")]
        public List<VwAnnualreport> GetAllRequestHeader()
        {
            List<VwAnnualreport> Records = new List<VwAnnualreport>();

            var conn = _context.Database.GetDbConnection();
            conn.Open();
            var comm = conn.CreateCommand();
            comm.CommandText = "SELECT * FROM VwAnnualreport";
            var reader = comm.ExecuteReader();
            while (reader.Read())
            {
                VwAnnualreport supplyRequest = new VwAnnualreport();
                supplyRequest.HospitalID = (int)reader["HospitalID"];
                supplyRequest.SupplyID = (string)reader["SupplyID"];
                supplyRequest.HospitalName = (string)reader["HospitalName"];
                supplyRequest.City = (string)reader["City"];
                supplyRequest.ItemCatName = (string)reader["ItemCatName"];
                supplyRequest.SupplyItemQty = Convert.ToInt32(reader["SupplyItemQty"]);
                supplyRequest.SupplyItemID = (int)reader["SupplyItemID"];
                supplyRequest.SupplyItemCat = (int)reader["SupplyItemCat"];
                supplyRequest.SupplyItemName = (string)reader["SupplyItemName"];
                supplyRequest.SupplyCreateDate = (DateTime)reader["SupplyCreateDate"];
                supplyRequest.SupplyExpireDate = (DateTime)reader["SupplyExpireDate"];
                supplyRequest.SupplyPriorityLevel = (int)reader["SupplyPriorityLevel"];
                Records.Add(supplyRequest);
            }
            conn.Close();

            return Records;
        }

        //Complaint


        [HttpPost]
        [ActionName("PostComplaint")]
        public async Task<IActionResult> PostComplaint([FromBody]  Complaint oData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                LastDocSerialNo record = _context.LastDocSerialNo.Where(x => x.DocCode == "CLN").FirstOrDefault();

                if (record == null)
                {
                    // Handle the case where the record doesn't exist
                    return NotFound();
                }

                record.DocCode = "CLN";
                record.LastTxnSerialNo = record.LastTxnSerialNo + 1;
                record.ModifiedBy = "admin";
                record.ModifiedDateTime = DateTime.Now;

                _context.Entry(record).State = EntityState.Modified;

                string NewDonationID = record.DocCode + record.LastTxnSerialNo.ToString("D3");
                oData.ComplaintCode = NewDonationID;

                _context.Complaint.Add(oData);
                await _context.SaveChangesAsync();

                return Ok(oData); // Return the inserted record
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException?.Message ?? ex.Message);
            }
        }


        //Hospital Dashboard

        [HttpGet("{HospitalID}")]
        [ActionName("GetHospitalDashboardData")]
        public HospitalDashboardDto GetHospitalDashboardData(int HospitalID)
        {
            HospitalDashboardDto result = new HospitalDashboardDto();

            result.registeredVolunteers = _context.VolunteerMaster.Where(x => x.HospitalID == HospitalID).Count();
            result.CountofTotalDonation = _context.DonationHeader.Where(x => x.HospitalID == HospitalID).Count();

            result.ContributeOrganization = (from A in _context.DonorMaster
                                             join B in _context.DonationHeader
                                             on A.DonorID equals B.DonorID
                                             where B.HospitalID == HospitalID && A.DonorType == 2
                                             select A).Count();

            result.NewDonors = (from A in _context.DonorMaster
                                join B in _context.DonationHeader
                                on A.DonorID equals B.DonorID
                                where B.HospitalID == HospitalID
                                select A).Count();

            result.Urgent = _context.SupplyRequestHeader.Where(x => x.HospitalID == HospitalID && x.SupplyPriorityLevel == 1).Count();
            result.Normal = _context.SupplyRequestHeader.Where(x => x.HospitalID == HospitalID && x.SupplyPriorityLevel == 2).Count();
            result.Low = _context.SupplyRequestHeader.Where(x => x.HospitalID == HospitalID && x.SupplyPriorityLevel == 3).Count();


            int requestqty1 = (int)(from A in _context.SupplyRequestHeader
                               join B in _context.SupplyRequestDetails
                               on A.SupplyID equals B.SupplyID
                               where A.HospitalID == HospitalID && A.SupplyStatus != 2 && A.SupplyPriorityLevel == 2
                               select B.SupplyItemQty).Sum();

            int donatedqty1 = (int)(from A in _context.SupplyRequestHeader
                               join B in _context.DonationDetails
                               on A.SupplyID equals B.SupplyID
                               where A.HospitalID == HospitalID && A.SupplyStatus != 2 && A.SupplyPriorityLevel == 2
                               select B.DonatedQty).Sum();

            int requestqty2 = (int)(from A in _context.SupplyRequestHeader
                               join B in _context.SupplyRequestDetails
                               on A.SupplyID equals B.SupplyID
                               where A.HospitalID == HospitalID && A.SupplyStatus != 2 && A.SupplyPriorityLevel == 1
                               select B.SupplyItemQty).Sum();

            int donatedqty2 = (int)(from A in _context.SupplyRequestHeader
                               join B in _context.DonationDetails
                               on A.SupplyID equals B.SupplyID
                               where A.HospitalID == HospitalID && A.SupplyStatus != 2 && A.SupplyPriorityLevel == 1
                               select B.DonatedQty).Sum();


            double donatedPercentage1 = (requestqty1 == 0) ? 0 : (double)donatedqty1 / requestqty1 * 100;

            // Round to 2 decimal places
            donatedPercentage1 = Convert.ToInt32(donatedPercentage1);
            result.RegularLevel = Convert.ToInt32(donatedPercentage1);

            double donatedPercentage2 = (requestqty2 == 0) ? 0 : (double)donatedqty2 / requestqty2 * 100;

            // Round to 2 decimal places
            donatedPercentage2 = Convert.ToInt32(donatedPercentage2);
            result.UrgentLevel = Convert.ToInt32(donatedPercentage2);

            return result;
        }

    }
}
