using Microsoft.EntityFrameworkCore.Migrations;

namespace GiveMED.Api.Migrations
{
    public partial class _24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VolunteerMaster",
                table: "VolunteerMaster");

            migrationBuilder.DropColumn(
                name: "VolID",
                table: "VolunteerMaster");

            migrationBuilder.DropColumn(
                name: "VolunteerEmail",
                table: "VolunteerMaster");

            migrationBuilder.AddColumn<string>(
                name: "VolCode",
                table: "VolunteerMaster",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VolEmail",
                table: "VolunteerMaster",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VolunteerMaster",
                table: "VolunteerMaster",
                column: "VolCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VolunteerMaster",
                table: "VolunteerMaster");

            migrationBuilder.DropColumn(
                name: "VolCode",
                table: "VolunteerMaster");

            migrationBuilder.DropColumn(
                name: "VolEmail",
                table: "VolunteerMaster");

            migrationBuilder.AddColumn<int>(
                name: "VolID",
                table: "VolunteerMaster",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "VolunteerEmail",
                table: "VolunteerMaster",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VolunteerMaster",
                table: "VolunteerMaster",
                column: "VolID");
        }
    }
}
