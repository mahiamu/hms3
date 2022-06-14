using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddResponsiblePersonRelationshipWithDifferentTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "ResponsiblePersons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "ResponsiblePersons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "ResponsiblePersons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RelationshipId",
                table: "ResponsiblePersons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ResponsiblePersons_CityId",
                table: "ResponsiblePersons",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsiblePersons_CountryId",
                table: "ResponsiblePersons",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsiblePersons_PatientId",
                table: "ResponsiblePersons",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsiblePersons_RelationshipId",
                table: "ResponsiblePersons",
                column: "RelationshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsiblePersons_Cities_CityId",
                table: "ResponsiblePersons",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsiblePersons_Countries_CountryId",
                table: "ResponsiblePersons",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsiblePersons_Patients_PatientId",
                table: "ResponsiblePersons",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsiblePersons_Relationships_RelationshipId",
                table: "ResponsiblePersons",
                column: "RelationshipId",
                principalTable: "Relationships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponsiblePersons_Cities_CityId",
                table: "ResponsiblePersons");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsiblePersons_Countries_CountryId",
                table: "ResponsiblePersons");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsiblePersons_Patients_PatientId",
                table: "ResponsiblePersons");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsiblePersons_Relationships_RelationshipId",
                table: "ResponsiblePersons");

            migrationBuilder.DropIndex(
                name: "IX_ResponsiblePersons_CityId",
                table: "ResponsiblePersons");

            migrationBuilder.DropIndex(
                name: "IX_ResponsiblePersons_CountryId",
                table: "ResponsiblePersons");

            migrationBuilder.DropIndex(
                name: "IX_ResponsiblePersons_PatientId",
                table: "ResponsiblePersons");

            migrationBuilder.DropIndex(
                name: "IX_ResponsiblePersons_RelationshipId",
                table: "ResponsiblePersons");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "ResponsiblePersons");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "ResponsiblePersons");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "ResponsiblePersons");

            migrationBuilder.DropColumn(
                name: "RelationshipId",
                table: "ResponsiblePersons");
        }
    }
}
