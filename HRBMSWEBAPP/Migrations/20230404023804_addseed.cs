using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRBMSWEBAPP.Migrations
{
    public partial class addseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "41f1d1c5-a4bb-48a0-8816-b2f27ed28df4", 0, "e0eb57d8-a7ae-4cfb-82f9-3c32dcd86bb2", "mark@gmail.com", false, "Mark", "Mayaman", false, null, null, null, null, "09125635896", false, "7004d573-981a-4c63-882d-449e91a26580", false, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c06d436e-526b-4371-aa49-bf3f1950820f", 0, "d366cd8c-5a2d-4d87-86d4-7a81bbd957aa", "ivhan@gmail.com", false, "Ivhan", "De Leon", false, null, null, null, null, "09079260368", false, "78ac0ffa-977c-4b24-8f48-8653c0ac5d42", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41f1d1c5-a4bb-48a0-8816-b2f27ed28df4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c06d436e-526b-4371-aa49-bf3f1950820f");
        }
    }
}
