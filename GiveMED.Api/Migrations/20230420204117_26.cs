using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiveMED.Api.Migrations
{
    public partial class _26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonationVolunteer",
                columns: table => new
                {
                    DonationCode = table.Column<string>(maxLength: 50, nullable: false),
                    SupplyCode = table.Column<string>(maxLength: 50, nullable: false),
                    HospitalID = table.Column<int>(nullable: false),
                    DonorID = table.Column<int>(nullable: false),
                    VolunteerCode = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationVolunteer", x => new { x.DonationCode, x.SupplyCode, x.VolunteerCode, x.HospitalID, x.DonorID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationVolunteer");
        }
    }
}
