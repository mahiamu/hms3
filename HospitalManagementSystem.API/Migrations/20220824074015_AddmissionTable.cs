using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddmissionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdmissionId",
                table: "Wards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdmissionId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdmissionId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdmissionId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Admissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdmissionTypeId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    PatientId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    RoomId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    WardId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    AdmissionTime = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    DischargeDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    IsDischarge = table.Column<bool>(type: "bit", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admissions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admissions_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admissions_Wards_WardId",
                        column: x => x.WardId,
                        principalTable: "Wards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wards_AdmissionId",
                table: "Wards",
                column: "AdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_AdmissionId",
                table: "Rooms",
                column: "AdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AdmissionId",
                table: "Patients",
                column: "AdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AdmissionId",
                table: "Employees",
                column: "AdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_EmployeeId",
                table: "Admissions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_PatientId",
                table: "Admissions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_RoomId",
                table: "Admissions",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_WardId",
                table: "Admissions",
                column: "WardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Admissions_AdmissionId",
                table: "Employees",
                column: "AdmissionId",
                principalTable: "Admissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Admissions_AdmissionId",
                table: "Patients",
                column: "AdmissionId",
                principalTable: "Admissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Admissions_AdmissionId",
                table: "Rooms",
                column: "AdmissionId",
                principalTable: "Admissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wards_Admissions_AdmissionId",
                table: "Wards",
                column: "AdmissionId",
                principalTable: "Admissions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Admissions_AdmissionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Admissions_AdmissionId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Admissions_AdmissionId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Wards_Admissions_AdmissionId",
                table: "Wards");

            migrationBuilder.DropTable(
                name: "Admissions");

            migrationBuilder.DropIndex(
                name: "IX_Wards_AdmissionId",
                table: "Wards");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_AdmissionId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Patients_AdmissionId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AdmissionId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AdmissionId",
                table: "Wards");

            migrationBuilder.DropColumn(
                name: "AdmissionId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "AdmissionId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "AdmissionId",
                table: "Employees");
        }
    }
}
