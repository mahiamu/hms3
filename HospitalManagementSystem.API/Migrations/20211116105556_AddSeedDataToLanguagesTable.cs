using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddSeedDataToLanguagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Languages (Name) VALUES ('English')");
            migrationBuilder.Sql("INSERT INTO Languages (Name) VALUES ('Amharic')");
            migrationBuilder.Sql("INSERT INTO Languages (Name) VALUES ('Afaan Oromo')");
            migrationBuilder.Sql("INSERT INTO Languages (Name) VALUES ('Tigrinya')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM Languages");
        }
    }
}
