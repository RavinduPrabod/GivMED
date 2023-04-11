using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiveMED.Api.Migrations
{
    public partial class _16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonationDetails",
                columns: table => new
                {
                    DonationID = table.Column<string>(maxLength: 50, nullable: false),
                    SupplyID = table.Column<string>(maxLength: 50, nullable: false),
                    ItemID = table.Column<int>(nullable: false),
                    ItemCategory = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(maxLength: 100, nullable: false),
                    RequestQty = table.Column<long>(nullable: false),
                    DonatedQty = table.Column<long>(nullable: false),
                    DonationStatus = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationDetails", x => new { x.DonationID, x.SupplyID, x.ItemCategory, x.ItemID });
                });

            migrationBuilder.CreateTable(
                name: "DonationHeader",
                columns: table => new
                {
                    DonationID = table.Column<string>(maxLength: 50, nullable: false),
                    DonorID = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    SupplyID = table.Column<string>(maxLength: 50, nullable: false),
                    HospitalID = table.Column<int>(nullable: false),
                    DonationStatus = table.Column<int>(nullable: false),
                    DonationCreateDate = table.Column<DateTime>(nullable: true),
                    DonationDealDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationHeader", x => new { x.DonationID, x.DonorID, x.UserName, x.SupplyID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationDetails");

            migrationBuilder.DropTable(
                name: "DonationHeader");
        }
    }
}
