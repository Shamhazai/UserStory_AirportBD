using Microsoft.EntityFrameworkCore.Migrations;

namespace UserStory_Airport.Migrations
{
    public partial class AddtestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "testMigration",
                table: "AirportDB",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "testMigration",
                table: "AirportDB");
        }
    }
}
