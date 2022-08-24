using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.API.Migrations
{
    public partial class BillScheduleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillScheduleId",
                table: "PatientSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillScheduleId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BillSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientScheduleId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillSchedules_PatientSchedules_PatientScheduleId",
                        column: x => x.PatientScheduleId,
                        principalTable: "PatientSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientSchedules_BillScheduleId",
                table: "PatientSchedules",
                column: "BillScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BillScheduleId",
                table: "Employees",
                column: "BillScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_BillSchedules_PatientScheduleId",
                table: "BillSchedules",
                column: "PatientScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_BillSchedules_BillScheduleId",
                table: "Employees",
                column: "BillScheduleId",
                principalTable: "BillSchedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientSchedules_BillSchedules_BillScheduleId",
                table: "PatientSchedules",
                column: "BillScheduleId",
                principalTable: "BillSchedules",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_BillSchedules_BillScheduleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientSchedules_BillSchedules_BillScheduleId",
                table: "PatientSchedules");

            migrationBuilder.DropTable(
                name: "BillSchedules");

            migrationBuilder.DropIndex(
                name: "IX_PatientSchedules_BillScheduleId",
                table: "PatientSchedules");

            migrationBuilder.DropIndex(
                name: "IX_Employees_BillScheduleId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BillScheduleId",
                table: "PatientSchedules");

            migrationBuilder.DropColumn(
                name: "BillScheduleId",
                table: "Employees");
        }
    }
}
