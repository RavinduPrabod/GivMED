using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiveMED.Api.Migrations
{
    public partial class _29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    ComplaintCode = table.Column<string>(maxLength: 50, nullable: false),
                    ComplanerName = table.Column<string>(maxLength: 50, nullable: false),
                    ComplanerEmail = table.Column<string>(maxLength: 50, nullable: false),
                    Subject = table.Column<string>(maxLength: 500, nullable: false),
                    NameofVictim = table.Column<string>(maxLength: 50, nullable: false),
                    FullComplaint = table.Column<string>(maxLength: 1000, nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.ComplaintCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaint");
        }
    }
}
