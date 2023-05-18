using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRBMSWEBAPP.Migrations
{
    public partial class getallbooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE OR ALTER PROCEDURE getallbooking
            AS
            BEGIN
                select * from Booking;
            END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE getallcategories";

            migrationBuilder.Sql(sp);
        }
    }
}
