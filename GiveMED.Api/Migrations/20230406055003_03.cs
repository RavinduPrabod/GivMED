using Microsoft.EntityFrameworkCore.Migrations;

namespace GiveMED.Api.Migrations
{
    public partial class _03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalMaster",
                table: "HospitalMaster");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalID",
                table: "HospitalMaster",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalMaster",
                table: "HospitalMaster",
                columns: new[] { "HospitalID", "RegistrationNo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalMaster",
                table: "HospitalMaster");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalID",
                table: "HospitalMaster",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalMaster",
                table: "HospitalMaster",
                column: "HospitalID");
        }
    }
}
