using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.API.Migrations
{
    public partial class PatientScheduleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientScheduleId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientScheduleId",
                table: "Patients",
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

            migrationBuilder.CreateTable(
                name: "PatientSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    AdmissionTypeId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Is_Payed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Is_Dismissed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientSchedules_AdmissionTypes_AdmissionTypeId",
                        column: x => x.AdmissionTypeId,
                        principalTable: "AdmissionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientSchedules_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientSchedules_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientSchedules_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_PatientScheduleId",
                table: "Rooms",
                column: "PatientScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PatientScheduleId",
                table: "Patients",
                column: "PatientScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PatientScheduleId",
                table: "Employees",
                column: "PatientScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionTypes_PatientScheduleId",
                table: "AdmissionTypes",
                column: "PatientScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSchedules_AdmissionTypeId",
                table: "PatientSchedules",
                column: "AdmissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSchedules_EmployeeId",
                table: "PatientSchedules",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSchedules_PatientId",
                table: "PatientSchedules",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSchedules_RoomId",
                table: "PatientSchedules",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionTypes_PatientSchedules_PatientScheduleId",
                table: "AdmissionTypes",
                column: "PatientScheduleId",
                principalTable: "PatientSchedules",
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
                name: "FK_Rooms_PatientSchedules_PatientScheduleId",
                table: "Rooms",
                column: "PatientScheduleId",
                principalTable: "PatientSchedules",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionTypes_PatientSchedules_PatientScheduleId",
                table: "AdmissionTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PatientSchedules_PatientScheduleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_PatientSchedules_PatientScheduleId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_PatientSchedules_PatientScheduleId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "PatientSchedules");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_PatientScheduleId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PatientScheduleId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PatientScheduleId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_AdmissionTypes_PatientScheduleId",
                table: "AdmissionTypes");

            migrationBuilder.DropColumn(
                name: "PatientScheduleId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "PatientScheduleId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientScheduleId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PatientScheduleId",
                table: "AdmissionTypes");
        }
    }
}
