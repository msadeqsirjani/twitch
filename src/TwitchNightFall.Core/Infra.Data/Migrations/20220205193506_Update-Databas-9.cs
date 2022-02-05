﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitchNightFall.Core.Migrations
{
    public partial class UpdateDatabas9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
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
                values: new object[] { new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(3176), new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(3177) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("06e71005-69d6-4ad4-b218-7bd47dbeed04"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7205), new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7206) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("42a62722-2c58-4f59-a81f-487141a288bb"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7190), new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7191) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("4b01f654-1410-492c-8b97-bbb9e142b372"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7196), new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7196) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("5f31bb44-ba41-4cba-97e5-e0152baeb259"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7212), new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7213) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("69b933c5-58d1-41d3-8abc-18dc0c5a40f4"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7204), new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7204) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("8d96397f-a217-43a7-8f9b-91cff10fd135"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7211), new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7211) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("8e5e29eb-2017-4d75-9cf6-7c8b8bf5b9b5"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7197), new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7198) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("95df2344-8fb7-4f20-bb51-f1bf1f5618c0"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7207), new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7207) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("b55bcaab-901e-4d30-8e82-e5572b84937c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7201), new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7201) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("d2fc0919-e8e6-4ad5-9561-456725280b59"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7199), new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7199) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("f75a9840-2c97-4f1c-91a0-fd6c68d49f4a"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7209), new DateTime(2022, 2, 5, 19, 35, 6, 166, DateTimeKind.Utc).AddTicks(7209) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                schema: "ray",
                table: "Subscription",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                values: new object[] { new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(1036), new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(1037) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("06e71005-69d6-4ad4-b218-7bd47dbeed04"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5103), new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5103) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("42a62722-2c58-4f59-a81f-487141a288bb"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5084), new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5085) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("4b01f654-1410-492c-8b97-bbb9e142b372"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5091), new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5091) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("5f31bb44-ba41-4cba-97e5-e0152baeb259"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5112), new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5112) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("69b933c5-58d1-41d3-8abc-18dc0c5a40f4"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5101), new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5101) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("8d96397f-a217-43a7-8f9b-91cff10fd135"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5109), new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5109) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("8e5e29eb-2017-4d75-9cf6-7c8b8bf5b9b5"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5093), new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5093) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("95df2344-8fb7-4f20-bb51-f1bf1f5618c0"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5105), new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5105) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("b55bcaab-901e-4d30-8e82-e5572b84937c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5097), new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5097) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("d2fc0919-e8e6-4ad5-9561-456725280b59"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5095), new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5095) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("f75a9840-2c97-4f1c-91a0-fd6c68d49f4a"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5106), new DateTime(2022, 2, 5, 19, 28, 19, 152, DateTimeKind.Utc).AddTicks(5107) });
        }
    }
}
