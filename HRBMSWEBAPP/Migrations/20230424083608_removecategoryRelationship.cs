using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRBMSWEBAPP.Migrations
{
    public partial class removecategoryRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Categories_RoomCategoriesId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_RoomCategoriesId",
                table: "Booking");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b54f0586-7909-4356-9383-950259b9bddc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4513b5c-8196-439f-ae88-0b9562e4bf0e");

            migrationBuilder.DropColumn(
                name: "RoomCategoriesId",
                table: "Booking");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "390e306e-65ab-4927-ba17-2d37b6fa31a4", "47bad451-5c48-41c3-8c46-c43003286340", "Guest", "GUEST" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "67b6b659-23b6-41d0-b48a-9760faec04ae", "6d2e9879-6e51-4114-8315-f189fed7aaf7", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "390e306e-65ab-4927-ba17-2d37b6fa31a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67b6b659-23b6-41d0-b48a-9760faec04ae");

            migrationBuilder.AddColumn<int>(
                name: "RoomCategoriesId",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b54f0586-7909-4356-9383-950259b9bddc", "1522e074-1103-4a7d-8b1e-d52d9d2f8856", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4513b5c-8196-439f-ae88-0b9562e4bf0e", "158ef852-0148-4bb2-bceb-532421ab2fb5", "Guest", "GUEST" });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_RoomCategoriesId",
                table: "Booking",
                column: "RoomCategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Categories_RoomCategoriesId",
                table: "Booking",
                column: "RoomCategoriesId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
