using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitchNightFall.Core.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ray");

            migrationBuilder.CreateTable(
                name: "Twitch",
                schema: "ray",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Twitch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forgiveness",
                schema: "ray",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TwitchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prize = table.Column<int>(type: "int", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forgiveness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forgiveness_Twitch_TwitchId",
                        column: x => x.TwitchId,
                        principalSchema: "ray",
                        principalTable: "Twitch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forgiveness_TwitchId",
                schema: "ray",
                table: "Forgiveness",
                column: "TwitchId");

            migrationBuilder.CreateIndex(
                name: "IX_TwitchAccount_Username",
                schema: "ray",
                table: "Twitch",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forgiveness",
                schema: "ray");

            migrationBuilder.DropTable(
                name: "Twitch",
                schema: "ray");
        }
    }
}
