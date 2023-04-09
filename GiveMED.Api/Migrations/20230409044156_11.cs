using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiveMED.Api.Migrations
{
    public partial class _11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplyItemQty",
                table: "SupplyRequestDetails");

            migrationBuilder.AlterColumn<string>(
                name: "SupplyID",
                table: "SupplyRequestHeader",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "LastDocSerialNo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "LastDocSerialNo");

            migrationBuilder.AlterColumn<string>(
                name: "SupplyID",
                table: "SupplyRequestHeader",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<long>(
                name: "SupplyItemQty",
                table: "SupplyRequestDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
