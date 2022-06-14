using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddRelationshipToReceptionistsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Receptionists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Receptionists_GenderId",
                table: "Receptionists",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receptionists_Genders_GenderId",
                table: "Receptionists",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receptionists_Genders_GenderId",
                table: "Receptionists");

            migrationBuilder.DropIndex(
                name: "IX_Receptionists_GenderId",
                table: "Receptionists");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Receptionists");
        }
    }
}
