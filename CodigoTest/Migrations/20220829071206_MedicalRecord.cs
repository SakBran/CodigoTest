using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldCities.Migrations
{
    public partial class MedicalRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bloodPressure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    perRectum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    temperature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SPO2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    historyOfPresentIllness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    drugHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    examination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    investigations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    treatment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pastMedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currentDrugs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalRecords");
        }
    }
}
