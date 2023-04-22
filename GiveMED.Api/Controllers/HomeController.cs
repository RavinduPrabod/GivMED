﻿using GiveMED.Api.Data;
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

        [HttpGet]
        [ActionName("GetTopTrendingDonations")]
        public IEnumerable<TopTrendingDonorDto> GetTopTrendingDonations()
        {
            List<TopTrendingDonorDto> Records = new List<TopTrendingDonorDto>();

            var conn = _context.Database.GetDbConnection();
            conn.Open();
            var comm = conn.CreateCommand();
            comm.CommandText = "SELECT C.SupplyID, A.DonationID, C.SupplyPriorityLevel, B.RequestQty, B.DonatedQty, A.DonorID, D.HospitalName, D.City, DonorCounts.DonorCount FROM DonationHeader A INNER JOIN DonationDetails B ON A.DonationID = B.DonationID LEFT OUTER JOIN SupplyRequestHeader C ON A.SupplyID = C.SupplyID INNER JOIN HospitalMaster D ON C.HospitalID = D.HospitalID INNER JOIN ( SELECT SupplyID, COUNT(DISTINCT DonorID) AS DonorCount FROM DonationHeader GROUP BY SupplyID ) DonorCounts ON C.SupplyID = DonorCounts.SupplyID";
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
    }
}
