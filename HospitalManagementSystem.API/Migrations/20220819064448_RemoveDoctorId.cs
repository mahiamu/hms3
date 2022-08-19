using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class RemoveDoctorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_Doctors_DoctorId",
                table: "Holidays");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_Doctors_DoctorId",
                table: "Recommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Doctors_DoctorId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Schedules",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_DoctorId",
                table: "Schedules",
                newName: "IX_Schedules_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Recommendations",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendations_DoctorId",
                table: "Recommendations",
                newName: "IX_Recommendations_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Prescriptions",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_DoctorId",
                table: "Prescriptions",
                newName: "IX_Prescriptions_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Holidays",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Holidays_DoctorId",
                table: "Holidays",
                newName: "IX_Holidays_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_Employees_EmployeeId",
                table: "Holidays",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Employees_EmployeeId",
                table: "Prescriptions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_Employees_EmployeeId",
                table: "Recommendations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Employees_EmployeeId",
                table: "Schedules",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_Employees_EmployeeId",
                table: "Holidays");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Employees_EmployeeId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_Employees_EmployeeId",
                table: "Recommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Employees_EmployeeId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Schedules",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_EmployeeId",
                table: "Schedules",
                newName: "IX_Schedules_DoctorId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Recommendations",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendations_EmployeeId",
                table: "Recommendations",
                newName: "IX_Recommendations_DoctorId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Prescriptions",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_EmployeeId",
                table: "Prescriptions",
                newName: "IX_Prescriptions_DoctorId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Holidays",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Holidays_EmployeeId",
                table: "Holidays",
                newName: "IX_Holidays_DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_Doctors_DoctorId",
                table: "Holidays",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorId",
                table: "Prescriptions",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_Doctors_DoctorId",
                table: "Recommendations",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Doctors_DoctorId",
                table: "Schedules",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
