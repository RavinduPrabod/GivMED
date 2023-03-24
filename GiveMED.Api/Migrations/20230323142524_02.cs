using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiveMED.Api.Migrations
{
    public partial class _02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HospitalMaster",
                columns: table => new
                {
                    HospitalID = table.Column<string>(maxLength: 50, nullable: false),
                    HospitalRegistrationNo = table.Column<string>(maxLength: 50, nullable: false),
                    HospitalName = table.Column<string>(maxLength: 200, nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    Telephone = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 50, nullable: true),
                    ModifieDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedUser = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalMaster", x => x.HospitalID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HospitalMaster");
        }
    }
}
