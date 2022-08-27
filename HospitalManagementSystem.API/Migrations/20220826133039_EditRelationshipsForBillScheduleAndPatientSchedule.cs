using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.API.Migrations
{
    public partial class EditRelationshipsForBillScheduleAndPatientSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionTypes_PatientSchedules_PatientScheduleId",
                table: "AdmissionTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_BillSchedules_BillScheduleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PatientSchedules_PatientScheduleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_PatientSchedules_PatientScheduleId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientSchedules_BillSchedules_BillScheduleId",
                table: "PatientSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_PatientSchedules_PatientScheduleId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_PatientScheduleId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_PatientSchedules_BillScheduleId",
                table: "PatientSchedules");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PatientScheduleId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Employees_BillScheduleId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PatientScheduleId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_BillSchedules_PatientScheduleId",
                table: "BillSchedules");

            migrationBuilder.DropIndex(
                name: "IX_AdmissionTypes_PatientScheduleId",
                table: "AdmissionTypes");

            migrationBuilder.DropColumn(
                name: "PatientScheduleId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "BillScheduleId",
                table: "PatientSchedules");

            migrationBuilder.DropColumn(
                name: "PatientScheduleId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "BillScheduleId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PatientScheduleId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PatientScheduleId",
                table: "AdmissionTypes");

            migrationBuilder.CreateIndex(
                name: "IX_BillSchedules_EmployeeId",
                table: "BillSchedules",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BillSchedules_PatientScheduleId",
                table: "BillSchedules",
                column: "PatientScheduleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BillSchedules_Employees_EmployeeId",
                table: "BillSchedules",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillSchedules_Employees_EmployeeId",
                table: "BillSchedules");

            migrationBuilder.DropIndex(
                name: "IX_BillSchedules_EmployeeId",
                table: "BillSchedules");

            migrationBuilder.DropIndex(
                name: "IX_BillSchedules_PatientScheduleId",
                table: "BillSchedules");

            migrationBuilder.AddColumn<int>(
                name: "PatientScheduleId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillScheduleId",
                table: "PatientSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientScheduleId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillScheduleId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientScheduleId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientScheduleId",
                table: "AdmissionTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_PatientScheduleId",
                table: "Rooms",
                column: "PatientScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSchedules_BillScheduleId",
                table: "PatientSchedules",
                column: "BillScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PatientScheduleId",
                table: "Patients",
                column: "PatientScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BillScheduleId",
                table: "Employees",
                column: "BillScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PatientScheduleId",
                table: "Employees",
                column: "PatientScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_BillSchedules_PatientScheduleId",
                table: "BillSchedules",
                column: "PatientScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionTypes_PatientScheduleId",
                table: "AdmissionTypes",
                column: "PatientScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionTypes_PatientSchedules_PatientScheduleId",
                table: "AdmissionTypes",
                column: "PatientScheduleId",
                principalTable: "PatientSchedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_BillSchedules_BillScheduleId",
                table: "Employees",
                column: "BillScheduleId",
                principalTable: "BillSchedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PatientSchedules_PatientScheduleId",
                table: "Employees",
                column: "PatientScheduleId",
                principalTable: "PatientSchedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_PatientSchedules_PatientScheduleId",
                table: "Patients",
                column: "PatientScheduleId",
                principalTable: "PatientSchedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientSchedules_BillSchedules_BillScheduleId",
                table: "PatientSchedules",
                column: "BillScheduleId",
                principalTable: "BillSchedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_PatientSchedules_PatientScheduleId",
                table: "Rooms",
                column: "PatientScheduleId",
                principalTable: "PatientSchedules",
                principalColumn: "Id");
        }
    }
}
