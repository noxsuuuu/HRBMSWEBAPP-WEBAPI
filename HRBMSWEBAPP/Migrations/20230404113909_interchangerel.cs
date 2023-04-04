using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRBMSWEBAPP.Migrations
{
    public partial class interchangerel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Room_RoomId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_RoomId",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e943cb7-2c16-45e4-941b-11427d08ec17");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6037f3a8-7d6d-4fa8-932a-16d765e79dd7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fdf767f0-7191-474e-8b00-474754da7ed2");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a8deb9ae-2b46-4b1c-9314-f441445697ef", 0, "3b73f19b-58ca-4dd8-83de-d0e310cce7a7", "admin@gmail.com", false, "Admin", "Manager", false, null, null, null, null, "09079260368", false, "088db5b3-3542-4e1d-a311-6489665e1006", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bb8149f1-792d-4db7-b613-cf9ccf00823c", 0, "e8e275f8-4cbc-4622-bb24-21cb250dc40c", "mark@gmail.com", false, "Mark", "Mayaman", false, null, null, null, null, "09125635896", false, "03676741-37c5-4b6e-8389-2ed984fd30c4", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cd631613-a962-44f2-a442-5855b19d2bf0", 0, "98735dd9-2d26-4a5d-a454-174a17cc7707", "ivhan@gmail.com", false, "Ivhan", "De Leon", false, null, null, null, null, "09079260368", false, "1336b091-472d-41fb-9aca-fb868608ac35", false, null });

            migrationBuilder.CreateIndex(
                name: "IX_Room_CategoryId",
                table: "Room",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Categories_CategoryId",
                table: "Room",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Categories_CategoryId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_CategoryId",
                table: "Room");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8deb9ae-2b46-4b1c-9314-f441445697ef");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb8149f1-792d-4db7-b613-cf9ccf00823c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd631613-a962-44f2-a442-5855b19d2bf0");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Room");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2e943cb7-2c16-45e4-941b-11427d08ec17", 0, "54e2f615-84b1-44b1-9779-3331fabc8c45", "ivhan@gmail.com", false, "Ivhan", "De Leon", false, null, null, null, null, "09079260368", false, "44caa3d7-032c-4e1f-9a63-7d9b1868e937", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6037f3a8-7d6d-4fa8-932a-16d765e79dd7", 0, "847085a2-c40b-46ff-81e2-303ccbbcd959", "mark@gmail.com", false, "Mark", "Mayaman", false, null, null, null, null, "09125635896", false, "fdbd85e7-8486-4257-a1b5-59acf16f6c69", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fdf767f0-7191-474e-8b00-474754da7ed2", 0, "98ae09ba-4e51-42c1-956a-e01ff46241a3", "admin@gmail.com", false, "Admin", "Manager", false, null, null, null, null, "09079260368", false, "a15b03d5-200d-4a35-bded-29aaf0560de6", false, null });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_RoomId",
                table: "Categories",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Room_RoomId",
                table: "Categories",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
