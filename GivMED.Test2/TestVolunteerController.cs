using GiveMED.Api.Controllers;
using GiveMED.Api.Data;
using GiveMED.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GivMED.Test2
{
    [TestClass]
    public class TestVolunteerController
    {
        private VolunteerController _controller;
        private DataContext _context;

        [TestInitialize]
        public void Initialize()
        {
            // Set up the test environment
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "db_GiveMED")
                .Options;
            _context = new DataContext(options);
            _controller = new VolunteerController(_context);
        }

        [TestMethod]
        public async Task PostVolunteerMaster_ValidModel_ReturnsOkResult()
        {
            _context.LastDocSerialNo.Add(new LastDocSerialNo
            {
                DocCode = "VLT",
                LastTxnSerialNo = 0,
                ModifiedBy = "admin",
                ModifiedDateTime = DateTime.Now
            });
            await _context.SaveChangesAsync();

            // Arrange
            var volunteer = new VolunteerMaster
            {
                VolCode = "",
                HospitalID = 1,
                VolNIC = "981310985V",
                VolName = "D.K. Yasan Lakmal Hemachandra",
                Address = "F250/2, NELUMPOKUNAGAMA, COLOMBO ROAD, ALAWWA",
                Telephone = "0779033226",
                VolEmail = "yasanhemachandra@gmail.com",
                VehicleCat = 1,
                VehicleNo = "None",
                VolSkill = 1,
                Status = 1,
                CreateDateTime = DateTime.Parse("2023-04-24 00:03:30.6284382"),
                CreateUser = "admin",
                ModifieDateTime = DateTime.Parse("2023-04-24 00:03:30.6284382"),
                ModifiedUser = "admin"
            };

            // Add test data to the in-memory database
            _context.VolunteerMaster.Add(volunteer);
            await _context.SaveChangesAsync();

            // Act
            var result = await _controller.PostVolunteerMaster(volunteer) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            Assert.AreEqual(volunteer, result.Value);
        }

        [TestMethod]
        public async Task GetVolunteerMaster_ExistingHospitalID_ReturnsListOfVolunteerMaster()
        {
            // Arrange
            int hospitalId = 1;

            // Act
            var result = _controller.GetVolunteerMaster(hospitalId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<VolunteerMaster>));
        }

        [TestMethod]
        public async Task GetVolunteerMasterbyID_ExistingVolCode_ReturnsVolunteerMaster()
        {
            // Arrange
            string volCode = "VLT003";
            // Add test data to the in-memory database
            _context.VolunteerMaster.Add(new VolunteerMaster { VolCode = volCode, /* add other properties */ });
            _context.SaveChanges();

            // Act
            var result = await _controller.GetVolunteerMasterbyID(volCode);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(VolunteerMaster));
            Assert.AreEqual(volCode, result.VolCode);
        }

        [TestMethod]
        public async Task GetAllActiveVolunteerMaster_ReturnsListOfVolunteerMaster()
        {
            // Act
            var result = _controller.GetAllActiveVolunteerMaster();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<VolunteerMaster>));
        }

        [TestMethod]
        public async Task PutVolunteerMaster_ValidModel_ReturnsOkResult()
        {
            // Arrange
            var volunteer = new VolunteerMaster
            {
                VolCode = "VLT002",
                HospitalID = 1,
                VolNIC = "981310985V",
                VolName = "D.K. Yasan Lakmal Hemachandra",
                Address = "F250/2, NELUMPOKUNAGAMA, COLOMBO ROAD, ALAWWA",
                Telephone = "0779033226",
                VolEmail = "yasanhemachandra@gmail.com",
                VehicleCat = 1,
                VehicleNo = "None",
                VolSkill = 1,
                Status = 1,
                CreateDateTime = DateTime.Parse("2023-04-24 00:03:30.6284382"),
                CreateUser = "admin",
                ModifieDateTime = DateTime.Parse("2023-04-24 00:03:30.6284382"),
                ModifiedUser = "admin"
            };

            // Add test data to the in-memory database
            _context.VolunteerMaster.Add(volunteer);
            await _context.SaveChangesAsync();

            // Act
            var result = await _controller.PutVolunteerMaster(volunteer) as OkObjectResult;


            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            Assert.AreEqual(volunteer, result.Value);
        }

        [TestMethod]
        public async Task DeleteVolunteerMasterbyID_ExistingVolCode_ReturnsOkResult()
        {
            // Arrange
            var volunteer = new VolunteerMaster { VolCode = "VLT001" };
            _context.VolunteerMaster.Add(volunteer);
            _context.SaveChanges();

            // Act
            var result = await _controller.DeleteVolunteerMasterbyID(volunteer) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            Assert.AreEqual(volunteer, result.Value);
        }
    }
}
