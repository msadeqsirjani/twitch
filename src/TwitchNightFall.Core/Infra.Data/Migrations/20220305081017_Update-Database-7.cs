using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitchNightFall.Core.Migrations
{
    public partial class UpdateDatabase7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "PlanId",
                schema: "ray",
                table: "ForgivenessAsync",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Administrator",
                keyColumn: "Id",
                keyValue: new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 10, 17, 519, DateTimeKind.Utc).AddTicks(9219), new DateTime(2022, 3, 5, 8, 10, 17, 519, DateTimeKind.Utc).AddTicks(9222) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("06e71005-69d6-4ad4-b218-7bd47dbeed04"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(3995), new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(3996) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("42a62722-2c58-4f59-a81f-487141a288bb"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(3938), new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(3939) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("4b01f654-1410-492c-8b97-bbb9e142b372"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(3946), new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(3947) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("5f31bb44-ba41-4cba-97e5-e0152baeb259"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(4010), new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(4010) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("69b933c5-58d1-41d3-8abc-18dc0c5a40f4"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(3961), new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(3962) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("8d96397f-a217-43a7-8f9b-91cff10fd135"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(4007), new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(4007) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("8e5e29eb-2017-4d75-9cf6-7c8b8bf5b9b5"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(3950), new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(3950) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("95df2344-8fb7-4f20-bb51-f1bf1f5618c0"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(3999), new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(3999) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("b55bcaab-901e-4d30-8e82-e5572b84937c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(3956), new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(3956) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("d2fc0919-e8e6-4ad5-9561-456725280b59"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(3953), new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(3953) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("f75a9840-2c97-4f1c-91a0-fd6c68d49f4a"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(4002), new DateTime(2022, 3, 5, 8, 10, 17, 520, DateTimeKind.Utc).AddTicks(4002) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "PlanId",
                schema: "ray",
                table: "ForgivenessAsync",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Administrator",
                keyColumn: "Id",
                keyValue: new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 9, 28, 850, DateTimeKind.Utc).AddTicks(5872), new DateTime(2022, 3, 5, 8, 9, 28, 850, DateTimeKind.Utc).AddTicks(5874) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("06e71005-69d6-4ad4-b218-7bd47dbeed04"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(88), new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(88) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("42a62722-2c58-4f59-a81f-487141a288bb"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(29), new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(29) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("4b01f654-1410-492c-8b97-bbb9e142b372"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(36), new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(37) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("5f31bb44-ba41-4cba-97e5-e0152baeb259"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(102), new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(102) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("69b933c5-58d1-41d3-8abc-18dc0c5a40f4"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(52), new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(52) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("8d96397f-a217-43a7-8f9b-91cff10fd135"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(99), new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(99) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("8e5e29eb-2017-4d75-9cf6-7c8b8bf5b9b5"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(41), new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(41) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("95df2344-8fb7-4f20-bb51-f1bf1f5618c0"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(91), new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(92) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("b55bcaab-901e-4d30-8e82-e5572b84937c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(48), new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(48) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("d2fc0919-e8e6-4ad5-9561-456725280b59"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(44), new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(45) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("f75a9840-2c97-4f1c-91a0-fd6c68d49f4a"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(95), new DateTime(2022, 3, 5, 8, 9, 28, 851, DateTimeKind.Utc).AddTicks(95) });
        }
    }
}
