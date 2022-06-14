using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddRelationshipToDonorsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BloodGroupId",
                table: "Donors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Donors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Donors_BloodGroupId",
                table: "Donors",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_GenderId",
                table: "Donors",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_BloodGroups_BloodGroupId",
                table: "Donors",
                column: "BloodGroupId",
                principalTable: "BloodGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Genders_GenderId",
                table: "Donors",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_BloodGroups_BloodGroupId",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Genders_GenderId",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_Donors_BloodGroupId",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_Donors_GenderId",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "BloodGroupId",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Donors");
        }
    }
}
