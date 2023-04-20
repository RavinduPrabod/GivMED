using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiveMED.Api.Migrations
{
    public partial class _19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VolunteerMaster",
                columns: table => new
                {
                    VolID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalID = table.Column<int>(nullable: false),
                    VolName = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: false),
                    Telephone = table.Column<string>(maxLength: 20, nullable: false),
                    VehicleCat = table.Column<string>(maxLength: 20, nullable: true),
                    VehicleNo = table.Column<string>(maxLength: 20, nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 50, nullable: true),
                    ModifieDateTime = table.Column<DateTime>(nullable: true),
                    ModifiedUser = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerMaster", x => x.VolID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VolunteerMaster");
        }
    }
}
