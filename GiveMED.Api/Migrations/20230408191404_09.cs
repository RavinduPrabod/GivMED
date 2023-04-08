using Microsoft.EntityFrameworkCore.Migrations;

namespace GiveMED.Api.Migrations
{
    public partial class _09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplyQty",
                table: "SupplyRequestHeader");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SupplyQty",
                table: "SupplyRequestHeader",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
