using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitchNightFall.Core.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TwitchAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwitchAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FollowerAwards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TwitchAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prize = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowerAwards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowerAwards_TwitchAccounts_TwitchAccountId",
                        column: x => x.TwitchAccountId,
                        principalTable: "TwitchAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FollowerAwards_TwitchAccountId",
                table: "FollowerAwards",
                column: "TwitchAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TwitchAccount_Username",
                table: "TwitchAccounts",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FollowerAwards");

            migrationBuilder.DropTable(
                name: "TwitchAccounts");
        }
    }
}
