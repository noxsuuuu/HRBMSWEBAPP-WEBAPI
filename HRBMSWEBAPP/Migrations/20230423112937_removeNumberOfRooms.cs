using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRBMSWEBAPP.Migrations
{
    public partial class removeNumberOfRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b231850f-bb21-4ea0-b4d2-259b0869c377");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc1283dc-d085-4f62-977d-1d360b528158");

            migrationBuilder.DropColumn(
                name: "NoOfRooms",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a8959cd-e056-49b1-a34e-34a549eb30df", "572b7f3f-2bb2-489a-bd18-fb085077f35f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c552899-ce07-497d-bda0-f40fb80f23fe", "d9cdac83-b2db-4a17-a6b3-78c4fc69be01", "Guest", "GUEST" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a8959cd-e056-49b1-a34e-34a549eb30df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c552899-ce07-497d-bda0-f40fb80f23fe");

            migrationBuilder.AddColumn<int>(
                name: "NoOfRooms",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b231850f-bb21-4ea0-b4d2-259b0869c377", "77137e00-dadf-4aa5-80b2-a37553118d68", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc1283dc-d085-4f62-977d-1d360b528158", "deb872e4-2d01-4b24-a93a-26b2db8fb38a", "Guest", "GUEST" });
        }
    }
}
