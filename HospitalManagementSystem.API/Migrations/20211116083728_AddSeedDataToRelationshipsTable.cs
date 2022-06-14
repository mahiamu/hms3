using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManagementSystem.API.Migrations
{
    public partial class AddSeedDataToRelationshipsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Relationships (Name) VALUES ('Mother')");
            migrationBuilder.Sql("INSERT INTO Relationships (Name) VALUES ('Father')");
            migrationBuilder.Sql("INSERT INTO Relationships (Name) VALUES ('Brother')");
            migrationBuilder.Sql("INSERT INTO Relationships (Name) VALUES ('Sister')");
            migrationBuilder.Sql("INSERT INTO Relationships (Name) VALUES ('Aunt')");
            migrationBuilder.Sql("INSERT INTO Relationships (Name) VALUES ('Uncle')");
            migrationBuilder.Sql("INSERT INTO Relationships (Name) VALUES ('Close relative')");
            migrationBuilder.Sql("INSERT INTO Relationships (Name) VALUES ('Other')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM Relationships");

        }
    }
}
