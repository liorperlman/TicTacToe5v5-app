using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Data.Migrations
{
    public partial class Pages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GamesPlayed",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "TurnCounter",
                table: "Game");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GamesPlayed",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TurnCounter",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
