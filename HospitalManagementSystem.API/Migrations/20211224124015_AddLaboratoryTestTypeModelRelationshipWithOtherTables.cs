using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddLaboratoryTestTypeModelRelationshipWithOtherTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LaboratoryTestCategoryId",
                table: "LaboratoryTestTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryTestTypes_LaboratoryTestCategoryId",
                table: "LaboratoryTestTypes",
                column: "LaboratoryTestCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryTestTypes_LaboratoryTestCategories_LaboratoryTestCategoryId",
                table: "LaboratoryTestTypes",
                column: "LaboratoryTestCategoryId",
                principalTable: "LaboratoryTestCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryTestTypes_LaboratoryTestCategories_LaboratoryTestCategoryId",
                table: "LaboratoryTestTypes");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryTestTypes_LaboratoryTestCategoryId",
                table: "LaboratoryTestTypes");

            migrationBuilder.DropColumn(
                name: "LaboratoryTestCategoryId",
                table: "LaboratoryTestTypes");
        }
    }
}
