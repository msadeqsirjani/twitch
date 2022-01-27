using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitchNightFall.Core.Migrations
{
    public partial class UpdateDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "ray",
                table: "Twitch",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "ray",
                table: "Twitch",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Administrator",
                keyColumn: "Id",
                keyValue: new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 1, 27, 9, 43, 22, 446, DateTimeKind.Utc).AddTicks(8272), new DateTime(2022, 1, 27, 9, 43, 22, 446, DateTimeKind.Utc).AddTicks(8273) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "ray",
                table: "Twitch");

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "ray",
                table: "Twitch");

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Administrator",
                keyColumn: "Id",
                keyValue: new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 1, 24, 18, 46, 39, 166, DateTimeKind.Utc).AddTicks(4211), new DateTime(2022, 1, 24, 18, 46, 39, 166, DateTimeKind.Utc).AddTicks(4213) });
        }
    }
}
