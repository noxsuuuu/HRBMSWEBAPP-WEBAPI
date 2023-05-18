using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.Metrics;
using System.Drawing;

#nullable disable

namespace HRBMSWEBAPP.Migrations
{
    public partial class deleteRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE OR ALTER PROCEDURE deleteroom @roomId INT
            AS
            BEGIN
                DELETE from Room WHERE roomId = @roomId;
            END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE deleteroom";

            migrationBuilder.Sql(sp);
        }
    }
}
