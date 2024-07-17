using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuideMeApp.Shared.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PK_TripDetail",
                schema: "dbo",
                table: "TripDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trip",
                schema: "dbo",
                table: "Trip");

            migrationBuilder.RenameTable(
                name: "TripDetail",
                schema: "dbo",
                newName: "TripDetails",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Trip",
                schema: "dbo",
                newName: "Trips",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_TripDetail_UserId",
                schema: "dbo",
                table: "TripDetails",
                newName: "IX_TripDetails_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Trip_GuideId",
                schema: "dbo",
                table: "Trips",
                newName: "IX_Trips_GuideId");

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                schema: "dbo",
                table: "TripDetails",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripDetails",
                schema: "dbo",
                table: "TripDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trips",
                schema: "dbo",
                table: "Trips",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetails_TripId",
                schema: "dbo",
                table: "TripDetails",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripDetails_Trips_TripId",
                schema: "dbo",
                table: "TripDetails",
                column: "TripId",
                principalSchema: "dbo",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripDetails_Users_UserId",
                schema: "dbo",
                table: "TripDetails",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Users_GuideId",
                schema: "dbo",
                table: "Trips",
                column: "GuideId",
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
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserSettings_UserSettingId",
                schema: "dbo",
                table: "Users",
                column: "UserSettingId",
                principalSchema: "dbo",
                principalTable: "UserSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripDetails_Trips_TripId",
                schema: "dbo",
                table: "TripDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TripDetails_Users_UserId",
                schema: "dbo",
                table: "TripDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Users_GuideId",
                schema: "dbo",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserSettings_UserSettingId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trips",
                schema: "dbo",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripDetails",
                schema: "dbo",
                table: "TripDetails");

            migrationBuilder.DropIndex(
                name: "IX_TripDetails_TripId",
                schema: "dbo",
                table: "TripDetails");

            migrationBuilder.DropColumn(
                name: "TripId",
                schema: "dbo",
                table: "TripDetails");

            migrationBuilder.RenameTable(
                name: "Trips",
                schema: "dbo",
                newName: "Trip",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "TripDetails",
                schema: "dbo",
                newName: "TripDetail",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_GuideId",
                schema: "dbo",
                table: "Trip",
                newName: "IX_Trip_GuideId");

            migrationBuilder.RenameIndex(
                name: "IX_TripDetails_UserId",
                schema: "dbo",
                table: "TripDetail",
                newName: "IX_TripDetail_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trip",
                schema: "dbo",
                table: "Trip",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripDetail",
                schema: "dbo",
                table: "TripDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Users_GuideId",
                schema: "dbo",
                table: "Trip",
                column: "GuideId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

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
    }
}
