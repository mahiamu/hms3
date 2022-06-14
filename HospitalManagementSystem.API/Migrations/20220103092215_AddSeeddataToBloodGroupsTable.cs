using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddSeeddataToBloodGroupsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO BloodGroups (Name) VALUES ('A')");
            migrationBuilder.Sql("INSERT INTO BloodGroups (Name) VALUES ('B')");
            migrationBuilder.Sql("INSERT INTO BloodGroups (Name) VALUES ('AB')");
            migrationBuilder.Sql("INSERT INTO BloodGroups (Name) VALUES ('O')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM BloodGroups");
        }
    }
}
