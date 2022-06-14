using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddSeedDataToCitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Addis Ababa')");
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Dire Dawa')");
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Hawassa')");
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Mekele')");
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Bahir Dar')");
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Adama')");
            migrationBuilder.Sql("INSERT INTO Cities (Name) VALUES ('Harar')");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM Cities");
        }
    }
}
