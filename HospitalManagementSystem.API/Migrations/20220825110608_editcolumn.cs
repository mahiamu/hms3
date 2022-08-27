using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.API.Migrations
{
    public partial class editcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientSchedules_BillSchedules_BillScheduleId",
                table: "PatientSchedules");

            migrationBuilder.DropIndex(
                name: "IX_PatientSchedules_BillScheduleId",
                table: "PatientSchedules");

            migrationBuilder.DropColumn(
                name: "BillScheduleId",
                table: "PatientSchedules");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillScheduleId",
                table: "PatientSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientSchedules_BillScheduleId",
                table: "PatientSchedules",
                column: "BillScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientSchedules_BillSchedules_BillScheduleId",
                table: "PatientSchedules",
                column: "BillScheduleId",
                principalTable: "BillSchedules",
                principalColumn: "Id");
        }
    }
}
