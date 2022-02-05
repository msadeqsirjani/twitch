using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitchNightFall.Core.Migrations
{
    public partial class UpdateDatabase6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "PlanTime",
                schema: "ray",
                table: "Subscription",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "PlanType",
                schema: "ray",
                table: "Subscription",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Administrator",
                keyColumn: "Id",
                keyValue: new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 1, 1, 621, DateTimeKind.Utc).AddTicks(130), new DateTime(2022, 2, 5, 19, 1, 1, 621, DateTimeKind.Utc).AddTicks(133) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanTime",
                schema: "ray",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "PlanType",
                schema: "ray",
                table: "Subscription");

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Administrator",
                keyColumn: "Id",
                keyValue: new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 18, 53, 40, 59, DateTimeKind.Utc).AddTicks(4935), new DateTime(2022, 2, 5, 18, 53, 40, 59, DateTimeKind.Utc).AddTicks(4936) });
        }
    }
}
