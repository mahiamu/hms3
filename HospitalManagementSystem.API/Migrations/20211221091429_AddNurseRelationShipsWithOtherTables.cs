using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddNurseRelationShipsWithOtherTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Nurses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedicalDepartmentId",
                table: "Nurses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_GenderId",
                table: "Nurses",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_MedicalDepartmentId",
                table: "Nurses",
                column: "MedicalDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_Genders_GenderId",
                table: "Nurses",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_MedicalDepartments_MedicalDepartmentId",
                table: "Nurses",
                column: "MedicalDepartmentId",
                principalTable: "MedicalDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_Genders_GenderId",
                table: "Nurses");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_MedicalDepartments_MedicalDepartmentId",
                table: "Nurses");

            migrationBuilder.DropIndex(
                name: "IX_Nurses_GenderId",
                table: "Nurses");

            migrationBuilder.DropIndex(
                name: "IX_Nurses_MedicalDepartmentId",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "MedicalDepartmentId",
                table: "Nurses");
        }
    }
}
