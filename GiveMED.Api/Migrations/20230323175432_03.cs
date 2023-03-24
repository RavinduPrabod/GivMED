using Microsoft.EntityFrameworkCore.Migrations;

namespace GiveMED.Api.Migrations
{
    public partial class _03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HospitalRegistrationNo",
                table: "HospitalMaster");

            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "HospitalMaster",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "HospitalMaster",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NoOfBeds",
                table: "HospitalMaster",
                maxLength: 20,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNo",
                table: "HospitalMaster",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "HospitalMaster",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TypeofHosptal",
                table: "HospitalMaster",
                maxLength: 2,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WebURL",
                table: "HospitalMaster",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "YearEstablish",
                table: "HospitalMaster",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "HospitalMaster",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "HospitalMaster");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "HospitalMaster");

            migrationBuilder.DropColumn(
                name: "NoOfBeds",
                table: "HospitalMaster");

            migrationBuilder.DropColumn(
                name: "RegistrationNo",
                table: "HospitalMaster");

            migrationBuilder.DropColumn(
                name: "State",
                table: "HospitalMaster");

            migrationBuilder.DropColumn(
                name: "TypeofHosptal",
                table: "HospitalMaster");

            migrationBuilder.DropColumn(
                name: "WebURL",
                table: "HospitalMaster");

            migrationBuilder.DropColumn(
                name: "YearEstablish",
                table: "HospitalMaster");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "HospitalMaster");

            migrationBuilder.AddColumn<string>(
                name: "HospitalRegistrationNo",
                table: "HospitalMaster",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
