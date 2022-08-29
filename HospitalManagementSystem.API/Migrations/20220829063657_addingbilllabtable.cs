using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.API.Migrations
{
    public partial class addingbilllabtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Labrequests_LabRequestId",
                table: "Admissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Labrequests_LabRequestId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Labrequests_Admissions_AdmissionId",
                table: "Labrequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Labrequests_Employees_EmployeeId",
                table: "Labrequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Labrequests_LaboratoryTestTypes_LaboratoryTestTypeId",
                table: "Labrequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Labrequests",
                table: "Labrequests");

            migrationBuilder.RenameTable(
                name: "Labrequests",
                newName: "LabRequests");

            migrationBuilder.RenameIndex(
                name: "IX_Labrequests_LaboratoryTestTypeId",
                table: "LabRequests",
                newName: "IX_LabRequests_LaboratoryTestTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Labrequests_EmployeeId",
                table: "LabRequests",
                newName: "IX_LabRequests_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Labrequests_AdmissionId",
                table: "LabRequests",
                newName: "IX_LabRequests_AdmissionId");

            migrationBuilder.AddColumn<int>(
                name: "BillLabId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LabRequests",
                table: "LabRequests",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BillLabs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabRequestId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Amount = table.Column<float>(type: "real", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmployeeId = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillLabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillLabs_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillLabs_LabRequests_LabRequestId",
                        column: x => x.LabRequestId,
                        principalTable: "LabRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BillLabId",
                table: "Employees",
                column: "BillLabId");

            migrationBuilder.CreateIndex(
                name: "IX_BillLabs_EmployeeId",
                table: "BillLabs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BillLabs_LabRequestId",
                table: "BillLabs",
                column: "LabRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_LabRequests_LabRequestId",
                table: "Admissions",
                column: "LabRequestId",
                principalTable: "LabRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_BillLabs_BillLabId",
                table: "Employees",
                column: "BillLabId",
                principalTable: "BillLabs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_LabRequests_LabRequestId",
                table: "Employees",
                column: "LabRequestId",
                principalTable: "LabRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LabRequests_Admissions_AdmissionId",
                table: "LabRequests",
                column: "AdmissionId",
                principalTable: "Admissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LabRequests_Employees_EmployeeId",
                table: "LabRequests",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LabRequests_LaboratoryTestTypes_LaboratoryTestTypeId",
                table: "LabRequests",
                column: "LaboratoryTestTypeId",
                principalTable: "LaboratoryTestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_LabRequests_LabRequestId",
                table: "Admissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_BillLabs_BillLabId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_LabRequests_LabRequestId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_LabRequests_Admissions_AdmissionId",
                table: "LabRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LabRequests_Employees_EmployeeId",
                table: "LabRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LabRequests_LaboratoryTestTypes_LaboratoryTestTypeId",
                table: "LabRequests");

            migrationBuilder.DropTable(
                name: "BillLabs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LabRequests",
                table: "LabRequests");

            migrationBuilder.DropIndex(
                name: "IX_Employees_BillLabId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BillLabId",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "LabRequests",
                newName: "Labrequests");

            migrationBuilder.RenameIndex(
                name: "IX_LabRequests_LaboratoryTestTypeId",
                table: "Labrequests",
                newName: "IX_Labrequests_LaboratoryTestTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_LabRequests_EmployeeId",
                table: "Labrequests",
                newName: "IX_Labrequests_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_LabRequests_AdmissionId",
                table: "Labrequests",
                newName: "IX_Labrequests_AdmissionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Labrequests",
                table: "Labrequests",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Labrequests_Admissions_AdmissionId",
                table: "Labrequests",
                column: "AdmissionId",
                principalTable: "Admissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Labrequests_Employees_EmployeeId",
                table: "Labrequests",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Labrequests_LaboratoryTestTypes_LaboratoryTestTypeId",
                table: "Labrequests",
                column: "LaboratoryTestTypeId",
                principalTable: "LaboratoryTestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
