using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.API.Migrations
{
    public partial class EditLabrequestRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Labrequests_LabRequestId",
                table: "Admissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Labrequests_LabRequestId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_LabRequestId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Admissions_LabRequestId",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "LabRequestId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LabRequestId",
                table: "Admissions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LabRequestId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LabRequestId",
                table: "Admissions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LabRequestId",
                table: "Employees",
                column: "LabRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_LabRequestId",
                table: "Admissions",
                column: "LabRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Labrequests_LabRequestId",
                table: "Admissions",
                column: "LabRequestId",
                principalTable: "Labrequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Labrequests_LabRequestId",
                table: "Employees",
                column: "LabRequestId",
                principalTable: "Labrequests",
                principalColumn: "Id");
        }
    }
}
