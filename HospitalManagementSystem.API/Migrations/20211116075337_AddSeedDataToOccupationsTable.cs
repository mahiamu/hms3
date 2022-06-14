using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddSeedDataToOccupationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Occupations (Name) VALUES ('private ')");
            migrationBuilder.Sql("INSERT INTO Occupations (Name) VALUES ('Government')");
            migrationBuilder.Sql("INSERT INTO Occupations (Name) VALUES ('Unemployed')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM Occupations");
        }
    }
}
