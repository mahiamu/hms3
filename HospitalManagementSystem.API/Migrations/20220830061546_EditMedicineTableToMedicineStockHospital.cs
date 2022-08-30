using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.API.Migrations
{
    public partial class EditMedicineTableToMedicineStockHospital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Medicines_MedicineId",
                table: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_MedicineId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "Prescriptions");

            migrationBuilder.CreateTable(
                name: "MedicineStockHospitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationId = table.Column<int>(type: "int", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedSupplierId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineStockHospitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineStockHospitas_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineStockHospitas_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineStockHospitas_MedSuppliers_MedSupplierId",
                        column: x => x.MedSupplierId,
                        principalTable: "MedSuppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineStockHospitas_EmployeeId",
                table: "MedicineStockHospitas",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineStockHospitas_MedicationId",
                table: "MedicineStockHospitas",
                column: "MedicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicineStockHospitas_MedSupplierId",
                table: "MedicineStockHospitas",
                column: "MedSupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineStockHospitas");

            migrationBuilder.AddColumn<int>(
                name: "MedicineId",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    MedicineCategoryId = table.Column<int>(type: "int", nullable: false),
                    Effects = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenericName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PurchasePrice = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicines_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicines_MedicineCategories_MedicineCategoryId",
                        column: x => x.MedicineCategoryId,
                        principalTable: "MedicineCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_MedicineId",
                table: "Prescriptions",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_CountryId",
                table: "Medicines",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicineCategoryId",
                table: "Medicines",
                column: "MedicineCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Medicines_MedicineId",
                table: "Prescriptions",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
