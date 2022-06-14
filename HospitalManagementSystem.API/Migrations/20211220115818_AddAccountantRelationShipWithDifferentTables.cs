using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddAccountantRelationShipWithDifferentTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Accountants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Accountants_GenderId",
                table: "Accountants",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accountants_Genders_GenderId",
                table: "Accountants",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accountants_Genders_GenderId",
                table: "Accountants");

            migrationBuilder.DropIndex(
                name: "IX_Accountants_GenderId",
                table: "Accountants");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Accountants");
        }
    }
}
