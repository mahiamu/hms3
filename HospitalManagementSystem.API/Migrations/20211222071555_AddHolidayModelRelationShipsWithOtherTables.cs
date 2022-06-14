using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddHolidayModelRelationShipsWithOtherTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Holidays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_DoctorId",
                table: "Holidays",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_Doctors_DoctorId",
                table: "Holidays",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_Doctors_DoctorId",
                table: "Holidays");

            migrationBuilder.DropIndex(
                name: "IX_Holidays_DoctorId",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Holidays");
        }
    }
}
