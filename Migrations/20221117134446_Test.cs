using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserStory_Airport.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirportDB",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    nomer_reisa = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    prib_time = table.Column<DateTime>(nullable: false),
                    passagiers_count = table.Column<int>(nullable: false),
                    ppassagiers__price = table.Column<double>(nullable: false),
                    ek_count = table.Column<int>(nullable: false),
                    ek_price = table.Column<double>(nullable: false),
                    procent = table.Column<double>(nullable: false),
                    allmoney = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportDB", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirportDB");
        }
    }
}
