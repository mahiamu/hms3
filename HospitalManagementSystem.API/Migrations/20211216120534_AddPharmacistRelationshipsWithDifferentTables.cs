using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddPharmacistRelationshipsWithDifferentTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Pharmacists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedicalDepartmentId",
                table: "Pharmacists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacists_GenderId",
                table: "Pharmacists",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacists_MedicalDepartmentId",
                table: "Pharmacists",
                column: "MedicalDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacists_Genders_GenderId",
                table: "Pharmacists",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacists_MedicalDepartments_MedicalDepartmentId",
                table: "Pharmacists",
                column: "MedicalDepartmentId",
                principalTable: "MedicalDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacists_Genders_GenderId",
                table: "Pharmacists");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacists_MedicalDepartments_MedicalDepartmentId",
                table: "Pharmacists");

            migrationBuilder.DropIndex(
                name: "IX_Pharmacists_GenderId",
                table: "Pharmacists");

            migrationBuilder.DropIndex(
                name: "IX_Pharmacists_MedicalDepartmentId",
                table: "Pharmacists");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Pharmacists");

            migrationBuilder.DropColumn(
                name: "MedicalDepartmentId",
                table: "Pharmacists");
        }
    }
}
