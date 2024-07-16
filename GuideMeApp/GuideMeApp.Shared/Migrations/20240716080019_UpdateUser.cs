using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuideMeApp.Shared.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Address_AddressId",
                schema: "dbo",
                table: "Trip");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_User_GuideId",
                schema: "dbo",
                table: "Trip");

            migrationBuilder.DropForeignKey(
                name: "FK_TripDetail_User_UserId",
                schema: "dbo",
                table: "TripDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Address_AddressId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserSetting_UserSettingId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Trip_AddressId",
                schema: "dbo",
                table: "Trip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSetting",
                schema: "dbo",
                table: "UserSetting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AddressId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_FirstName_LastName",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                schema: "dbo",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "AddressId",
                schema: "dbo",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "AddressId",
                schema: "dbo",
                table: "User");

            migrationBuilder.RenameTable(
                name: "UserSetting",
                schema: "dbo",
                newName: "UserSettings",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "dbo",
                newName: "Users",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "dbo",
                newName: "Roles",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_User_UserSettingId",
                schema: "dbo",
                table: "Users",
                newName: "IX_Users_UserSettingId");

            migrationBuilder.RenameIndex(
                name: "IX_User_RoleId",
                schema: "dbo",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.AddColumn<string>(
                name: "Address_AddressLine1",
                schema: "dbo",
                table: "Trip",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_AddressLine2",
                schema: "dbo",
                table: "Trip",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_AddressLine3",
                schema: "dbo",
                table: "Trip",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                schema: "dbo",
                table: "Trip",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                schema: "dbo",
                table: "Trip",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                schema: "dbo",
                table: "Trip",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                schema: "dbo",
                table: "Trip",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_AddressLine1",
                schema: "dbo",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_AddressLine2",
                schema: "dbo",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_AddressLine3",
                schema: "dbo",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                schema: "dbo",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                schema: "dbo",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                schema: "dbo",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                schema: "dbo",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSettings",
                schema: "dbo",
                table: "UserSettings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "dbo",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                schema: "dbo",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Users_GuideId",
                schema: "dbo",
                table: "Trip",
                column: "GuideId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripDetail_Users_UserId",
                schema: "dbo",
                table: "TripDetail",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                schema: "dbo",
                table: "Users",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserSettings_UserSettingId",
                schema: "dbo",
                table: "Users",
                column: "UserSettingId",
                principalSchema: "dbo",
                principalTable: "UserSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Users_GuideId",
                schema: "dbo",
                table: "Trip");

            migrationBuilder.DropForeignKey(
                name: "FK_TripDetail_Users_UserId",
                schema: "dbo",
                table: "TripDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserSettings_UserSettingId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSettings",
                schema: "dbo",
                table: "UserSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                schema: "dbo",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Address_AddressLine1",
                schema: "dbo",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "Address_AddressLine2",
                schema: "dbo",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "Address_AddressLine3",
                schema: "dbo",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "Address_City",
                schema: "dbo",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                schema: "dbo",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                schema: "dbo",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "Address_State",
                schema: "dbo",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "Address_AddressLine1",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_AddressLine2",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_AddressLine3",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_City",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_State",
                schema: "dbo",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "UserSettings",
                schema: "dbo",
                newName: "UserSetting",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "dbo",
                newName: "User",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "dbo",
                newName: "Role",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserSettingId",
                schema: "dbo",
                table: "User",
                newName: "IX_User_UserSettingId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                schema: "dbo",
                table: "User",
                newName: "IX_User_RoleId");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                schema: "dbo",
                table: "Trip",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                schema: "dbo",
                table: "User",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSetting",
                schema: "dbo",
                table: "UserSetting",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "dbo",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                schema: "dbo",
                table: "Role",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    State = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trip_AddressId",
                schema: "dbo",
                table: "Trip",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AddressId",
                schema: "dbo",
                table: "User",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_User_FirstName_LastName",
                schema: "dbo",
                table: "User",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Address_AddressId",
                schema: "dbo",
                table: "Trip",
                column: "AddressId",
                principalSchema: "dbo",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_User_GuideId",
                schema: "dbo",
                table: "Trip",
                column: "GuideId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripDetail_User_UserId",
                schema: "dbo",
                table: "TripDetail",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Address_AddressId",
                schema: "dbo",
                table: "User",
                column: "AddressId",
                principalSchema: "dbo",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                schema: "dbo",
                table: "User",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserSetting_UserSettingId",
                schema: "dbo",
                table: "User",
                column: "UserSettingId",
                principalSchema: "dbo",
                principalTable: "UserSetting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
