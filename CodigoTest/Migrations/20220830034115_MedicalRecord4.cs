using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldCities.Migrations
{
    public partial class MedicalRecord4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "perRectum",
                table: "MedicalRecords",
                newName: "pulseRate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "pulseRate",
                table: "MedicalRecords",
                newName: "perRectum");
        }
    }
}
