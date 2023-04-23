using Microsoft.EntityFrameworkCore.Migrations;

namespace GiveMED.Api.Migrations
{
    public partial class _28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FunctionId",
                table: "EmailUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "EmailUsers",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "EmailUsers",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmailNotification",
                table: "EmailUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Publicity",
                table: "EmailUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "EmailUsers");

            migrationBuilder.DropColumn(
                name: "EmailNotification",
                table: "EmailUsers");

            migrationBuilder.DropColumn(
                name: "Publicity",
                table: "EmailUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "EmailUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "FunctionId",
                table: "EmailUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
