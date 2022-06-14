using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddSeedDataToWeekdayTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("INSERT INTO Weekdays (Name) VALUES ('Monday')");
            migrationBuilder.Sql("INSERT INTO Weekdays (Name) VALUES ('Tuesday')");
            migrationBuilder.Sql("INSERT INTO Weekdays (Name) VALUES ('Wednesday')");
            migrationBuilder.Sql("INSERT INTO Weekdays (Name) VALUES ('Thursday')");
            migrationBuilder.Sql("INSERT INTO Weekdays (Name) VALUES ('Friday')");
            migrationBuilder.Sql("INSERT INTO Weekdays (Name) VALUES ('Saturday')");
            migrationBuilder.Sql("INSERT INTO Weekdays (Name) VALUES ('Sunday')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM Weekdays");
        }
    }
}
