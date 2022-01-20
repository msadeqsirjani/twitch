using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitchNightFall.Core.Migrations
{
    public partial class UpdateDatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrator",
                schema: "ray",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "ray",
                table: "Administrator",
                columns: new[] { "Id", "CreatedAt", "Firstname", "Lastname", "ModifiedAt", "Password", "ProfileImageUrl", "Username" },
                values: new object[] { new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"), new DateTime(2022, 1, 20, 6, 55, 56, 576, DateTimeKind.Utc).AddTicks(8514), "admin", "admin", new DateTime(2022, 1, 20, 6, 55, 56, 576, DateTimeKind.Utc).AddTicks(8517), "0LfMrUOaFgd0CpvCf0oVBg==", null, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_Username",
                schema: "ray",
                table: "Administrator",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator",
                schema: "ray");
        }
    }
}
