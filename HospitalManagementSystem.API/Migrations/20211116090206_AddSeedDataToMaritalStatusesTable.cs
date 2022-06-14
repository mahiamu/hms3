using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddSeedDataToMaritalStatusesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MaritalStatuses (Name) VALUES ('Single')");
            migrationBuilder.Sql("INSERT INTO MaritalStatuses (Name) VALUES ('Married')");
            migrationBuilder.Sql("INSERT INTO MaritalStatuses (Name) VALUES ('Widowed')");
            migrationBuilder.Sql("INSERT INTO MaritalStatuses (Name) VALUES ('Divorced')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM MaritalStatuses");
        }
    }
}
