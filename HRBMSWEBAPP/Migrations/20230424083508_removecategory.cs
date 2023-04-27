using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRBMSWEBAPP.Migrations
{
    public partial class removecategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "512594de-f939-4836-aae6-149064bf7f6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd47534b-5eb4-4890-9fd9-d6d24f0ef786");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b54f0586-7909-4356-9383-950259b9bddc", "1522e074-1103-4a7d-8b1e-d52d9d2f8856", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4513b5c-8196-439f-ae88-0b9562e4bf0e", "158ef852-0148-4bb2-bceb-532421ab2fb5", "Guest", "GUEST" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b54f0586-7909-4356-9383-950259b9bddc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4513b5c-8196-439f-ae88-0b9562e4bf0e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "512594de-f939-4836-aae6-149064bf7f6a", "27fb9f81-def0-4d61-b247-453fbd27ef80", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd47534b-5eb4-4890-9fd9-d6d24f0ef786", "58866ad3-18c5-4cc3-af79-047b75809691", "Guest", "GUEST" });
        }
    }
}
