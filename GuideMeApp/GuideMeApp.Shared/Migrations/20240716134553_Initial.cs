using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuideMeApp.Shared.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScreenReader = table.Column<bool>(type: "INTEGER", nullable: false),
                    BlinkBlocker = table.Column<bool>(type: "INTEGER", nullable: false),
                    TextEnlargement = table.Column<bool>(type: "INTEGER", nullable: false),
                    HighContrast = table.Column<bool>(type: "INTEGER", nullable: false),
                    TextReader = table.Column<bool>(type: "INTEGER", nullable: false),
                    VoiceCommands = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserGroup = table.Column<int>(type: "INTEGER", nullable: false),
                    Image = table.Column<byte[]>(type: "BLOB", nullable: true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserSettingId = table.Column<int>(type: "INTEGER", nullable: false),
                    Address_AddressLine1 = table.Column<string>(type: "TEXT", nullable: true),
                    Address_AddressLine2 = table.Column<string>(type: "TEXT", nullable: true),
                    Address_AddressLine3 = table.Column<string>(type: "TEXT", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_State = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Country = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserSettings_UserSettingId",
                        column: x => x.UserSettingId,
                        principalSchema: "dbo",
                        principalTable: "UserSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Image = table.Column<byte[]>(type: "BLOB", nullable: false),
                    GuideId = table.Column<int>(type: "INTEGER", nullable: false),
                    Address_AddressLine1 = table.Column<string>(type: "TEXT", nullable: true),
                    Address_AddressLine2 = table.Column<string>(type: "TEXT", nullable: true),
                    Address_AddressLine3 = table.Column<string>(type: "TEXT", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_State = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Country = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trip_Users_GuideId",
                        column: x => x.GuideId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TripDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripDetail_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trip_GuideId",
                schema: "dbo",
                table: "Trip",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetail_UserId",
                schema: "dbo",
                table: "TripDetail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                schema: "dbo",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserSettingId",
                schema: "dbo",
                table: "Users",
                column: "UserSettingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trip",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TripDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserSettings",
                schema: "dbo");
        }
    }
}
