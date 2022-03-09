using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitchNightFall.Core.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ray");

            migrationBuilder.CreateTable(
                name: "Administrator",
                schema: "ray",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrator_Administrator_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "ray",
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Twitch",
                schema: "ray",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Twitch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForgivenessAsync",
                schema: "ray",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TwitchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prize = table.Column<int>(type: "int", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AdministratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forgiveness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forgiveness_Administrator_AdministratorId",
                        column: x => x.AdministratorId,
                        principalSchema: "ray",
                        principalTable: "Administrator",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Forgiveness_Administrator_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "ray",
                        principalTable: "Administrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Forgiveness_Twitch_TwitchId",
                        column: x => x.TwitchId,
                        principalSchema: "ray",
                        principalTable: "Twitch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                schema: "ray",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TwitchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_Plan_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "ray",
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscription_Twitch_TwitchId",
                        column: x => x.TwitchId,
                        principalSchema: "ray",
                        principalTable: "Twitch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                schema: "ray",
                table: "Administrator",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Firstname", "IsActive", "Lastname", "ModifiedAt", "Password", "ProfileImageUrl", "Username" },
                values: new object[] { new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"), new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(3210), null, "admin", true, "admin", new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(3212), "0LfMrUOaFgd0CpvCf0oVBg==", null, "admin" });

            migrationBuilder.InsertData(
                schema: "ray",
                table: "Plan",
                columns: new[] { "Id", "Count", "CreatedAt", "DelayBetweenEveryPurchase", "ModifiedAt", "PlanTime", "PlanType", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("06e71005-69d6-4ad4-b218-7bd47dbeed04"), 450, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9679), 30, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9679), "Monthly", "PurchaseFollower", 14.49m, "Subscription of 450 people per month" },
                    { new Guid("42a62722-2c58-4f59-a81f-487141a288bb"), 10, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9656), 5, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9657), "Daily", "LuckRound", 0.99m, "10 rounds of luck one to five followers" },
                    { new Guid("4b01f654-1410-492c-8b97-bbb9e142b372"), 140, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9663), 7, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9664), "Weekly", "PurchaseFollower", 5.49m, "Subscription of 140 people per week" },
                    { new Guid("5f31bb44-ba41-4cba-97e5-e0152baeb259"), 750, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9688), 30, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9688), "Monthly", "PurchaseFollower", 22.99m, "Subscription of 750 people per month" },
                    { new Guid("69b933c5-58d1-41d3-8abc-18dc0c5a40f4"), 300, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9676), 30, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9677), "Monthly", "PurchaseFollower", 9.99m, "Subscription of 300 people per month" },
                    { new Guid("8d96397f-a217-43a7-8f9b-91cff10fd135"), 70, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9686), 7, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9686), "Weekly", "PurchaseFollower", 2.99m, "Subscription of 70 people per week" },
                    { new Guid("8e5e29eb-2017-4d75-9cf6-7c8b8bf5b9b5"), 150, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9667), 30, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9667), "Monthly", "PurchaseFollower", 4.99m, "Subscription of 150 people per month" },
                    { new Guid("95df2344-8fb7-4f20-bb51-f1bf1f5618c0"), 50, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9681), 10, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9681), "Daily", "LuckRound", 3.49m, "50 rounds of luck one to five followers" },
                    { new Guid("b55bcaab-901e-4d30-8e82-e5572b84937c"), 20, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9673), 5, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9673), "Daily", "LuckRound", 1.89m, "20 rounds of luck one to five followers" },
                    { new Guid("d2fc0919-e8e6-4ad5-9561-456725280b59"), 175, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9670), 7, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9670), "Weekly", "PurchaseFollower", 6.49m, "Subscription of 175 people per week" },
                    { new Guid("f75a9840-2c97-4f1c-91a0-fd6c68d49f4a"), 600, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9683), 30, new DateTime(2022, 2, 21, 11, 40, 43, 296, DateTimeKind.Utc).AddTicks(9683), "Monthly", "PurchaseFollower", 18.99m, "Subscription of 600 people per month" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_CreatedBy",
                schema: "ray",
                table: "Administrator",
                column: "CreatedBy",
                unique: true,
                filter: "[CreatedBy] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_Username",
                schema: "ray",
                table: "Administrator",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Forgiveness_AdministratorId",
                schema: "ray",
                table: "ForgivenessAsync",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Forgiveness_ModifiedBy",
                schema: "ray",
                table: "ForgivenessAsync",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Forgiveness_TwitchId",
                schema: "ray",
                table: "ForgivenessAsync",
                column: "TwitchId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_PlanId",
                schema: "ray",
                table: "Subscription",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_TwitchId",
                schema: "ray",
                table: "Subscription",
                column: "TwitchId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TwitchAccount_Username",
                schema: "ray",
                table: "Twitch",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForgivenessAsync",
                schema: "ray");

            migrationBuilder.DropTable(
                name: "Subscription",
                schema: "ray");

            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "ray");

            migrationBuilder.DropTable(
                name: "Administrator",
                schema: "ray");

            migrationBuilder.DropTable(
                name: "Plan",
                schema: "ray");

            migrationBuilder.DropTable(
                name: "Twitch",
                schema: "ray");
        }
    }
}
