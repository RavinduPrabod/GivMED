using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiveMED.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FundraiserMaster",
                columns: table => new
                {
                    FundraiserID = table.Column<string>(maxLength: 50, nullable: false),
                    FundraiserName = table.Column<string>(maxLength: 200, nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: false),
                    Telephone = table.Column<string>(maxLength: 20, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    ContactPerson = table.Column<string>(maxLength: 50, nullable: false),
                    Designation = table.Column<string>(maxLength: 50, nullable: false),
                    OrganizationType = table.Column<int>(nullable: false),
                    RegType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 50, nullable: true),
                    ModifieDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedUser = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundraiserMaster", x => x.FundraiserID);
                });

            migrationBuilder.CreateTable(
                name: "HospitalMaster",
                columns: table => new
                {
                    HospitalID = table.Column<string>(maxLength: 50, nullable: false),
                    HospitalName = table.Column<string>(maxLength: 200, nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: false),
                    Telephone = table.Column<string>(maxLength: 20, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    ContactPerson = table.Column<string>(maxLength: 50, nullable: false),
                    Designation = table.Column<string>(maxLength: 50, nullable: false),
                    TypeofHosptal = table.Column<int>(nullable: false),
                    RegistrationNo = table.Column<string>(maxLength: 50, nullable: false),
                    YearEstablish = table.Column<int>(nullable: false),
                    NoOfBeds = table.Column<int>(nullable: false),
                    WebURL = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 50, nullable: true),
                    ModifieDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedUser = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalMaster", x => x.HospitalID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    NoOfAttempts = table.Column<int>(nullable: false),
                    LastLoginDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    CreatedWorkStation = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedWorkStation = table.Column<string>(maxLength: 50, nullable: true),
                    UserEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundraiserMaster");

            migrationBuilder.DropTable(
                name: "HospitalMaster");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
