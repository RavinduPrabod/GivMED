using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiveMED.Api.Migrations
{
    public partial class _18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublicStatus",
                table: "DonorMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DonationFeedback",
                columns: table => new
                {
                    SupplyCode = table.Column<string>(maxLength: 50, nullable: false),
                    DonationID = table.Column<string>(maxLength: 50, nullable: false),
                    DonorID = table.Column<int>(nullable: false),
                    HospitalID = table.Column<int>(nullable: false),
                    FeedbackText = table.Column<string>(maxLength: 1000, nullable: false),
                    StartRatings = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationFeedback", x => new { x.DonationID, x.SupplyCode });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationFeedback");

            migrationBuilder.DropColumn(
                name: "PublicStatus",
                table: "DonorMaster");
        }
    }
}
