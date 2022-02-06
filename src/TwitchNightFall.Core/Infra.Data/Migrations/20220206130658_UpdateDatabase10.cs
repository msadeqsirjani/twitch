using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitchNightFall.Core.Migrations
{
    public partial class UpdateDatabase10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transaction",
                schema: "ray",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TwitchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Plan_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "ray",
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_Twitch_TwitchId",
                        column: x => x.TwitchId,
                        principalSchema: "ray",
                        principalTable: "Twitch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Administrator",
                keyColumn: "Id",
                keyValue: new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(2520), new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(2522) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("06e71005-69d6-4ad4-b218-7bd47dbeed04"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6943), new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6944) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("42a62722-2c58-4f59-a81f-487141a288bb"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6926), new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6927) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("4b01f654-1410-492c-8b97-bbb9e142b372"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6931), new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6932) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("5f31bb44-ba41-4cba-97e5-e0152baeb259"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6952), new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6952) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("69b933c5-58d1-41d3-8abc-18dc0c5a40f4"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6942), new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6942) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("8d96397f-a217-43a7-8f9b-91cff10fd135"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6950), new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6950) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("8e5e29eb-2017-4d75-9cf6-7c8b8bf5b9b5"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6934), new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6934) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("95df2344-8fb7-4f20-bb51-f1bf1f5618c0"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6945), new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6945) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("b55bcaab-901e-4d30-8e82-e5572b84937c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6938), new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6938) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("d2fc0919-e8e6-4ad5-9561-456725280b59"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6936), new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6936) });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Plan",
                keyColumn: "Id",
                keyValue: new Guid("f75a9840-2c97-4f1c-91a0-fd6c68d49f4a"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6947), new DateTime(2022, 2, 6, 13, 6, 58, 292, DateTimeKind.Utc).AddTicks(6947) });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_PlanId",
                schema: "ray",
                table: "Transaction",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TwitchId",
                schema: "ray",
                table: "Transaction",
                column: "TwitchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "ray");

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
    }
}
