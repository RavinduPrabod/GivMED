using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiveMED.Api.Migrations
{
    public partial class _02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundraiserMaster");

            migrationBuilder.CreateTable(
                name: "DonorMaster",
                columns: table => new
                {
                    FundraiserID = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    DonorName = table.Column<string>(maxLength: 200, nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: false),
                    Telephone = table.Column<string>(maxLength: 20, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    ContactPerson = table.Column<string>(maxLength: 50, nullable: false),
                    Designation = table.Column<string>(maxLength: 50, nullable: false),
                    OrgType = table.Column<int>(nullable: false),
                    RegType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 50, nullable: true),
                    ModifieDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedUser = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorMaster", x => new { x.FundraiserID, x.UserName });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonorMaster");

            migrationBuilder.CreateTable(
                name: "FundraiserMaster",
                columns: table => new
                {
                    FundraiserID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FundraiserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModifieDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OrganizationType = table.Column<int>(type: "int", nullable: false),
                    RegType = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundraiserMaster", x => x.FundraiserID);
                });
        }
    }
}
