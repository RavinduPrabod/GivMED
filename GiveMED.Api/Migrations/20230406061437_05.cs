using Microsoft.EntityFrameworkCore.Migrations;

namespace GiveMED.Api.Migrations
{
    public partial class _05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalMaster",
                table: "HospitalMaster");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "HospitalMaster",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalMaster",
                table: "HospitalMaster",
                columns: new[] { "UserName", "HospitalID", "RegistrationNo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalMaster",
                table: "HospitalMaster");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "HospitalMaster");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalMaster",
                table: "HospitalMaster",
                columns: new[] { "HospitalID", "RegistrationNo" });
        }
    }
}
