using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitchNightFall.Core.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ForgivenessType",
                schema: "ray",
                table: "ForgivenessAsync",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Administrator",
                keyColumn: "Id",
                keyValue: new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(1207), new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(1209) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("06e71005-69d6-4ad4-b218-7bd47dbeed04"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6143), new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6143) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("42a62722-2c58-4f59-a81f-487141a288bb"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6120), new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6121) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("4b01f654-1410-492c-8b97-bbb9e142b372"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6127), new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6128) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("5f31bb44-ba41-4cba-97e5-e0152baeb259"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6153), new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6153) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("69b933c5-58d1-41d3-8abc-18dc0c5a40f4"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6141), new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6141) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("8d96397f-a217-43a7-8f9b-91cff10fd135"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6151), new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6151) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("8e5e29eb-2017-4d75-9cf6-7c8b8bf5b9b5"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6131), new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6131) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("95df2344-8fb7-4f20-bb51-f1bf1f5618c0"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6145), new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6146) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("b55bcaab-901e-4d30-8e82-e5572b84937c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6137), new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6137) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("d2fc0919-e8e6-4ad5-9561-456725280b59"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6134), new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6135) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("f75a9840-2c97-4f1c-91a0-fd6c68d49f4a"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6147), new DateTime(2022, 2, 21, 12, 45, 47, 942, DateTimeKind.Utc).AddTicks(6148) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForgivenessType",
                schema: "ray",
                table: "ForgivenessAsync");

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Administrator",
                keyColumn: "Id",
                keyValue: new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(3210), new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(3212) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("06e71005-69d6-4ad4-b218-7bd47dbeed04"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9679), new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9679) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("42a62722-2c58-4f59-a81f-487141a288bb"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9656), new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9657) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("4b01f654-1410-492c-8b97-bbb9e142b372"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9663), new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9664) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("5f31bb44-ba41-4cba-97e5-e0152baeb259"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9688), new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9688) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("69b933c5-58d1-41d3-8abc-18dc0c5a40f4"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9676), new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9677) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("8d96397f-a217-43a7-8f9b-91cff10fd135"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9686), new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9686) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("8e5e29eb-2017-4d75-9cf6-7c8b8bf5b9b5"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9667), new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9667) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("95df2344-8fb7-4f20-bb51-f1bf1f5618c0"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9681), new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9681) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("b55bcaab-901e-4d30-8e82-e5572b84937c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9673), new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9673) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("d2fc0919-e8e6-4ad5-9561-456725280b59"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9670), new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9670) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("f75a9840-2c97-4f1c-91a0-fd6c68d49f4a"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9683), new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9683) });
        }
    }
}
