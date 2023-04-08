using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiveMED.Api.Migrations
{
    public partial class _08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemCat",
                table: "ItemMaster");

            migrationBuilder.AddColumn<int>(
                name: "ItemCatID",
                table: "ItemMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ItemCatMaster",
                columns: table => new
                {
                    ItemCatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCatName = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCatMaster", x => x.ItemCatID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCatMaster");

            migrationBuilder.DropColumn(
                name: "ItemCatID",
                table: "ItemMaster");

            migrationBuilder.AddColumn<int>(
                name: "ItemCat",
                table: "ItemMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
