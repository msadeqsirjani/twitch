using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitchNightFall.Core.Migrations
{
    public partial class UpdateDatabase7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanTime",
                schema: "ray",
                table: "Subscription");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                schema: "ray",
                table: "Subscription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Plan",
                schema: "ray",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    PlanType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DelayBetweenEveryPurchase = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "ray",
                table: "Administrator",
                keyColumn: "Id",
                keyValue: new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 2, 5, 19, 25, 38, 838, DateTimeKind.Utc).AddTicks(955), new DateTime(2022, 2, 5, 19, 25, 38, 838, DateTimeKind.Utc).AddTicks(958) });

            migrationBuilder.InsertData(
                schema: "ray",
                table: "Plan",
                columns: new[] { "Id", "Count", "CreatedAt", "DelayBetweenEveryPurchase", "ModifiedAt", "PlanTime", "PlanType", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("06e71005-69d6-4ad4-b218-7bd47dbeed04"), 450, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly", "PurchaseFollower", 14.49m, "Subscription of 450 people per month" },
                    { new Guid("42a62722-2c58-4f59-a81f-487141a288bb"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daily", "LuckRound", 0.99m, "10 rounds of luck one to five followers" },
                    { new Guid("4b01f654-1410-492c-8b97-bbb9e142b372"), 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekly", "PurchaseFollower", 5.49m, "Subscription of 140 people per week" },
                    { new Guid("5f31bb44-ba41-4cba-97e5-e0152baeb259"), 750, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly", "PurchaseFollower", 22.99m, "Subscription of 750 people per month" },
                    { new Guid("69b933c5-58d1-41d3-8abc-18dc0c5a40f4"), 300, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly", "PurchaseFollower", 9.99m, "Subscription of 300 people per month" },
                    { new Guid("8d96397f-a217-43a7-8f9b-91cff10fd135"), 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekly", "PurchaseFollower", 2.99m, "Subscription of 70 people per week" },
                    { new Guid("8e5e29eb-2017-4d75-9cf6-7c8b8bf5b9b5"), 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly", "PurchaseFollower", 4.99m, "Subscription of 150 people per month" },
                    { new Guid("95df2344-8fb7-4f20-bb51-f1bf1f5618c0"), 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daily", "LuckRound", 3.49m, "50 rounds of luck one to five followers" },
                    { new Guid("b55bcaab-901e-4d30-8e82-e5572b84937c"), 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daily", "LuckRound", 1.89m, "20 rounds of luck one to five followers" },
                    { new Guid("d2fc0919-e8e6-4ad5-9561-456725280b59"), 175, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekly", "PurchaseFollower", 6.49m, "Subscription of 175 people per week" },
                    { new Guid("f75a9840-2c97-4f1c-91a0-fd6c68d49f4a"), 600, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly", "PurchaseFollower", 18.99m, "Subscription of 600 people per month" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_PlanId",
                schema: "ray",
                table: "Subscription",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Plan_PlanId",
                schema: "ray",
                table: "Subscription",
                column: "PlanId",
                principalSchema: "ray",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Plan_PlanId",
                schema: "ray",
                table: "Subscription");

            migrationBuilder.DropTable(
                name: "Plan",
                schema: "ray");

            migrationBuilder.DropIndex(
                name: "IX_Subscription_PlanId",
                schema: "ray",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "Count",
                schema: "ray",
                table: "Subscription");

            migrationBuilder.AddColumn<byte>(
                name: "PlanTime",
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
    }
}
