using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddRecommendationModelRelationshipWithOtherTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Recommendations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Recommendations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_DoctorId",
                table: "Recommendations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_PatientId",
                table: "Recommendations",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_Doctors_DoctorId",
                table: "Recommendations",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_Patients_PatientId",
                table: "Recommendations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_Doctors_DoctorId",
                table: "Recommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_Patients_PatientId",
                table: "Recommendations");

            migrationBuilder.DropIndex(
                name: "IX_Recommendations_DoctorId",
                table: "Recommendations");

            migrationBuilder.DropIndex(
                name: "IX_Recommendations_PatientId",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Recommendations");
        }
    }
}
