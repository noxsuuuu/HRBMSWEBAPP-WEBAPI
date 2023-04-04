using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRBMSWEBAPP.Migrations
{
    public partial class newdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1407d71c-aad3-428f-b4f7-5c206a70172b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32ff9353-4c76-4503-b6dd-b5e71aa2c493");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc6ca66a-3752-471f-817b-133dcd221905");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2ebf4aa4-3e10-4001-acf6-7a3f5cbe25d9", 0, "e0f47f55-b222-4d66-bb8d-e97e21101edb", "ivhan@gmail.com", false, "Ivhan", "De Leon", false, null, null, null, null, "09079260368", false, "c4816e30-3859-48c2-98ba-9213ec6f85b2", false, null },
                    { "5c3f00c2-0254-4c5f-a869-1af939070b13", 0, "4eb7d26e-f2c6-4675-924a-daf62322310c", "mark@gmail.com", false, "Mark", "Mayaman", false, null, null, null, null, "09125635896", false, "3c966461-aa84-4f26-b6c7-a5921d559b22", false, null },
                    { "b782f13b-6dd1-4ae5-9a1e-046b6d671bb8", 0, "157efd5f-1393-43e1-8f7f-18a6a5582c6f", "admin@gmail.com", false, "Admin", "Manager", false, null, null, null, null, "09079260368", false, "e81cf781-7b5d-4666-8f8b-63e696459b3a", false, null }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "sheesh");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "yeaaaaaaaa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2ebf4aa4-3e10-4001-acf6-7a3f5cbe25d9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5c3f00c2-0254-4c5f-a869-1af939070b13");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b782f13b-6dd1-4ae5-9a1e-046b6d671bb8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1407d71c-aad3-428f-b4f7-5c206a70172b", 0, "f8c37cb7-96ee-46a4-8408-ab178fe98a03", "ivhan@gmail.com", false, "Ivhan", "De Leon", false, null, null, null, null, "09079260368", false, "4a122ca4-ad58-4e7c-8989-54d3d6c72782", false, null },
                    { "32ff9353-4c76-4503-b6dd-b5e71aa2c493", 0, "56e5a8ed-9aab-48d5-9fce-71a3832aeb94", "mark@gmail.com", false, "Mark", "Mayaman", false, null, null, null, null, "09125635896", false, "21f55725-cac0-4439-b915-19f60b3ffb05", false, null },
                    { "bc6ca66a-3752-471f-817b-133dcd221905", 0, "aff78d2b-ece5-4be2-8338-af5d3f3c6fe8", "admin@gmail.com", false, "Admin", "Manager", false, null, null, null, null, "09079260368", false, "bd450b35-dd8f-4c61-a8a6-ff3f5da2c7b5", false, null }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Tite");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Pepe");
        }
    }
}
