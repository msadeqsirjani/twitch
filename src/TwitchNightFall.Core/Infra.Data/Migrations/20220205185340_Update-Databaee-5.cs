using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitchNightFall.Core.Migrations
{
    public partial class UpdateDatabase5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredAt",
                schema: "ray",
                table: "Subscription",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Administrator",
                keyColumn: "Id",
                keyValue: new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 18, 53, 40, 59, DateTimeKind.Utc).AddTicks(4935), new DateTime(2022, 2, 5, 18, 53, 40, 59, DateTimeKind.Utc).AddTicks(4936) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiredAt",
                schema: "ray",
                table: "Subscription");

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Administrator",
                keyColumn: "Id",
                keyValue: new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 18, 10, 1, 751, DateTimeKind.Utc).AddTicks(6824), new DateTime(2022, 2, 5, 18, 10, 1, 751, DateTimeKind.Utc).AddTicks(6826) });
        }
    }
}
