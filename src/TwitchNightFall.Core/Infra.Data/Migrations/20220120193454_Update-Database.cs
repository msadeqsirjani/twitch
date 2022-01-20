using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitchNightFall.Core.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Administrator",
                keyColumn: "Id",
                keyValue: new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 34, 53, 520, DateTimeKind.Utc).AddTicks(6929), new DateTime(2022, 1, 20, 19, 34, 53, 520, DateTimeKind.Utc).AddTicks(6933) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Administrator",
                keyColumn: "Id",
                keyValue: new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 1, 20, 19, 18, 3, 109, DateTimeKind.Utc).AddTicks(5419), new DateTime(2022, 1, 20, 19, 18, 3, 109, DateTimeKind.Utc).AddTicks(5421) });
        }
    }
}
