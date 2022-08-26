using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.API.Migrations
{
    public partial class addingLabRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LabRequestId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LabRequestId",
                table: "Admissions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Labrequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdmissionId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    OrderedDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    LaboratoryTestTypeId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Result = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labrequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Labrequests_Admissions_AdmissionId",
                        column: x => x.AdmissionId,
                        principalTable: "Admissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Labrequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Labrequests_LaboratoryTestTypes_LaboratoryTestTypeId",
                        column: x => x.LaboratoryTestTypeId,
                        principalTable: "LaboratoryTestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LabRequestId",
                table: "Employees",
                column: "LabRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_LabRequestId",
                table: "Admissions",
                column: "LabRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Labrequests_AdmissionId",
                table: "Labrequests",
                column: "AdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Labrequests_EmployeeId",
                table: "Labrequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Labrequests_LaboratoryTestTypeId",
                table: "Labrequests",
                column: "LaboratoryTestTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Labrequests_LabRequestId",
                table: "Admissions",
                column: "LabRequestId",
                principalTable: "Labrequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Labrequests_LabRequestId",
                table: "Employees",
                column: "LabRequestId",
                principalTable: "Labrequests",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Labrequests_LabRequestId",
                table: "Admissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Labrequests_LabRequestId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Labrequests");

            migrationBuilder.DropIndex(
                name: "IX_Employees_LabRequestId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Admissions_LabRequestId",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "LabRequestId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LabRequestId",
                table: "Admissions");
        }
    }
}
