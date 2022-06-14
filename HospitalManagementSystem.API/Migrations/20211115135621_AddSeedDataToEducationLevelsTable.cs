using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddSeedDataToEducationLevelsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO EducationLevels (Name) VALUES ('No formal education')");
            migrationBuilder.Sql("INSERT INTO EducationLevels (Name) VALUES ('Primary education')");
            migrationBuilder.Sql("INSERT INTO EducationLevels (Name) VALUES ('Secondary education or high school')");
            migrationBuilder.Sql("INSERT INTO EducationLevels (Name) VALUES ('Bachelors degree')");
            migrationBuilder.Sql("INSERT INTO EducationLevels (Name) VALUES ('Masters degree')");
            migrationBuilder.Sql("INSERT INTO EducationLevels (Name) VALUES ('Doctorate or higher')");
            

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM EducationLevels");
        }
    }
}
