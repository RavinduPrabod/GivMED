using GiveMED.Api.Data;
using GiveMED.Api.Dto;
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
                "INNER JOIN HospitalMaster E ON D.HospitalID = E.HospitalID";
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
    }
}
