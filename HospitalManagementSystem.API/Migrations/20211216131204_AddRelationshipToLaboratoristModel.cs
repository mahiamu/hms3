using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddRelationshipToLaboratoristModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Laboratoriests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedicalDepartmentId",
                table: "Laboratoriests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laboratoriests_GenderId",
                table: "Laboratoriests",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Laboratoriests_MedicalDepartmentId",
                table: "Laboratoriests",
                column: "MedicalDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laboratoriests_Genders_GenderId",
                table: "Laboratoriests",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Laboratoriests_MedicalDepartments_MedicalDepartmentId",
                table: "Laboratoriests",
                column: "MedicalDepartmentId",
                principalTable: "MedicalDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laboratoriests_Genders_GenderId",
                table: "Laboratoriests");

            migrationBuilder.DropForeignKey(
                name: "FK_Laboratoriests_MedicalDepartments_MedicalDepartmentId",
                table: "Laboratoriests");

            migrationBuilder.DropIndex(
                name: "IX_Laboratoriests_GenderId",
                table: "Laboratoriests");

            migrationBuilder.DropIndex(
                name: "IX_Laboratoriests_MedicalDepartmentId",
                table: "Laboratoriests");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Laboratoriests");

            migrationBuilder.DropColumn(
                name: "MedicalDepartmentId",
                table: "Laboratoriests");
        }
    }
}
