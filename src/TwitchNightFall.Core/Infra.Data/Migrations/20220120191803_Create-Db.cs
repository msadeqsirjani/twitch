using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitchNightFall.Core.Migrations
{
    public partial class CreateDb : Migration
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
                name: "Forgiveness",
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

            migrationBuilder.InsertData(
                schema: "ray",
                table: "Administrator",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Firstname", "IsActive", "Lastname", "ModifiedAt", "Password", "ProfileImageUrl", "Username" },
                values: new object[] { new Guid("c0915809-b937-4e84-b7ba-97efcf9af77c"), new DateTime(2022, 1, 20, 19, 18, 3, 109, DateTimeKind.Utc).AddTicks(5419), null, "admin", true, "admin", new DateTime(2022, 1, 20, 19, 18, 3, 109, DateTimeKind.Utc).AddTicks(5421), "0LfMrUOaFgd0CpvCf0oVBg==", null, "admin" });

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
                table: "Forgiveness",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Forgiveness_ModifiedBy",
                schema: "ray",
                table: "Forgiveness",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Forgiveness_TwitchId",
                schema: "ray",
                table: "Forgiveness",
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
                name: "Forgiveness",
                schema: "ray");

            migrationBuilder.DropTable(
                name: "Administrator",
                schema: "ray");

            migrationBuilder.DropTable(
                name: "Twitch",
                schema: "ray");
        }
    }
}
