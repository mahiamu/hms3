using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.API.Migrations
{
    public partial class EditLabRequestRelationships2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Admissions_AdmissionId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AdmissionId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AdmissionId",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdmissionId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AdmissionId",
                table: "Employees",
                column: "AdmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Admissions_AdmissionId",
                table: "Employees",
                column: "AdmissionId",
                principalTable: "Admissions",
                principalColumn: "Id");
        }
    }
}
