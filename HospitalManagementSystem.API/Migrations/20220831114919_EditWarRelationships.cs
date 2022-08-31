using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.API.Migrations
{
    public partial class EditWarRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wards_Admissions_AdmissionId",
                table: "Wards");

            migrationBuilder.DropIndex(
                name: "IX_Wards_AdmissionId",
                table: "Wards");

            migrationBuilder.DropColumn(
                name: "AdmissionId",
                table: "Wards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdmissionId",
                table: "Wards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wards_AdmissionId",
                table: "Wards",
                column: "AdmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wards_Admissions_AdmissionId",
                table: "Wards",
                column: "AdmissionId",
                principalTable: "Admissions",
                principalColumn: "Id");
        }
    }
}
