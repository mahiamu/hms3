using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class ConfigureRelationshipOfPatientsAndMaritalStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaritalStatusId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MaritalStatusId",
                table: "Patients",
                column: "MaritalStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_MaritalStatuses_MaritalStatusId",
                table: "Patients",
                column: "MaritalStatusId",
                principalTable: "MaritalStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_MaritalStatuses_MaritalStatusId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MaritalStatusId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MaritalStatusId",
                table: "Patients");
        }
    }
}
