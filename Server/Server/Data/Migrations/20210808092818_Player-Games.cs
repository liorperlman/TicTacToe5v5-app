using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Data.Migrations
{
    public partial class PlayerGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Game_PlayerID",
                table: "Game",
                column: "PlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Player_PlayerID",
                table: "Game",
                column: "PlayerID",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Player_PlayerID",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_PlayerID",
                table: "Game");
        }
    }
}
