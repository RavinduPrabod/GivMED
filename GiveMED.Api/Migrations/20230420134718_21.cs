using Microsoft.EntityFrameworkCore.Migrations;

namespace GiveMED.Api.Migrations
{
    public partial class _21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VolSkill",
                table: "VolunteerMaster",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VolunteerEmail",
                table: "VolunteerMaster",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VolSkill",
                table: "VolunteerMaster");

            migrationBuilder.DropColumn(
                name: "VolunteerEmail",
                table: "VolunteerMaster");
        }
    }
}
