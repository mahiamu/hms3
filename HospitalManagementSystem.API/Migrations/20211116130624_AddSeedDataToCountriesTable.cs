using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddSeedDataToCountriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Ethiopia')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Eritrea')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Somalia')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Kenya')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Djibouti')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES ('Sudan')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM Countries");
        }
    }
}
