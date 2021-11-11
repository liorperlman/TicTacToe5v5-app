using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Data.Migrations
{
    public partial class Date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Player_PlayerID",
                table: "Game");

            migrationBuilder.DropTable(
                name: "Step");

            migrationBuilder.RenameColumn(
                name: "PlayerID",
                table: "Game",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Game",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Game_PlayerID",
                table: "Game",
                newName: "IX_Game_PlayerId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Player",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Player",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Game",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Player_PlayerId",
                table: "Game",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Player_PlayerId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Game",
                newName: "PlayerID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Game",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Game_PlayerId",
                table: "Game",
                newName: "IX_Game_PlayerID");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Player",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Player",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Step_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Step_GameID",
                table: "Step",
                column: "GameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Player_PlayerID",
                table: "Game",
                column: "PlayerID",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
