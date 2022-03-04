using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitchNightFall.Core.Migrations
{
    public partial class UpdateDatabase5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlanId",
                schema: "ray",
                table: "Forgiveness",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Administrator",
                keyColumn: "Id",
                keyValue: new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 12, 40, 20, 728, DateTimeKind.Utc).AddTicks(9243), new DateTime(2022, 3, 4, 12, 40, 20, 728, DateTimeKind.Utc).AddTicks(9246) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("06e71005-69d6-4ad4-b218-7bd47dbeed04"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8546), new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8547) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("42a62722-2c58-4f59-a81f-487141a288bb"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8505), new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8506) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("4b01f654-1410-492c-8b97-bbb9e142b372"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8516), new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8516) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("5f31bb44-ba41-4cba-97e5-e0152baeb259"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8580), new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8580) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("69b933c5-58d1-41d3-8abc-18dc0c5a40f4"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8542), new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8542) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("8d96397f-a217-43a7-8f9b-91cff10fd135"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8575), new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8576) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("8e5e29eb-2017-4d75-9cf6-7c8b8bf5b9b5"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8521), new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8521) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("95df2344-8fb7-4f20-bb51-f1bf1f5618c0"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8551), new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8551) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("b55bcaab-901e-4d30-8e82-e5572b84937c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8533), new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8534) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("d2fc0919-e8e6-4ad5-9561-456725280b59"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8529), new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8529) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("f75a9840-2c97-4f1c-91a0-fd6c68d49f4a"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8556), new DateTime(2022, 3, 4, 12, 40, 20, 729, DateTimeKind.Utc).AddTicks(8557) });

            migrationBuilder.CreateIndex(
                name: "IX_Forgiveness_PlanId",
                schema: "ray",
                table: "Forgiveness",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forgiveness_Plan_PlanId",
                schema: "ray",
                table: "Forgiveness",
                column: "PlanId",
                principalSchema: "ray",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forgiveness_Plan_PlanId",
                schema: "ray",
                table: "Forgiveness");

            migrationBuilder.DropIndex(
                name: "IX_Forgiveness_PlanId",
                schema: "ray",
                table: "Forgiveness");

            migrationBuilder.DropColumn(
                name: "PlanId",
                schema: "ray",
                table: "Forgiveness");

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
    }
}
