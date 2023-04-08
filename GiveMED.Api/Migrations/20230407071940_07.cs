using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiveMED.Api.Migrations
{
    public partial class _07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemMaster",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(maxLength: 100, nullable: false),
                    ItemCat = table.Column<int>(nullable: false),
                    ItemDescription = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMaster", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "SupplyRequestDetails",
                columns: table => new
                {
                    SupplyID = table.Column<int>(nullable: false),
                    SupplyItemID = table.Column<int>(nullable: false),
                    SupplyItemCat = table.Column<int>(nullable: false),
                    SupplyItemName = table.Column<string>(maxLength: 100, nullable: false),
                    SupplyItemQty = table.Column<long>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyRequestDetails", x => new { x.SupplyID, x.SupplyItemID });
                });

            migrationBuilder.CreateTable(
                name: "SupplyRequestHeader",
                columns: table => new
                {
                    HospitalID = table.Column<int>(nullable: false),
                    SupplyID = table.Column<int>(nullable: false),
                    SupplyCreateDate = table.Column<DateTime>(nullable: true),
                    SupplyExpireDate = table.Column<DateTime>(nullable: true),
                    SupplyQty = table.Column<long>(nullable: false),
                    SupplyNarration = table.Column<string>(nullable: true),
                    SupplyPriorityLevel = table.Column<int>(nullable: false),
                    SupplyType = table.Column<int>(nullable: false),
                    SupplyStatus = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyRequestHeader", x => new { x.HospitalID, x.SupplyID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemMaster");

            migrationBuilder.DropTable(
                name: "SupplyRequestDetails");

            migrationBuilder.DropTable(
                name: "SupplyRequestHeader");
        }
    }
}
