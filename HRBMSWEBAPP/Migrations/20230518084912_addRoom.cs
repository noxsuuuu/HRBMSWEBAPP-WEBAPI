using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Xml.Linq;

#nullable disable

namespace HRBMSWEBAPP.Migrations
{
    public partial class addRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE OR ALTER PROCEDURE addroom
            @CategoryId INT
            @Status bit,
            AS
            BEGIN
               INSERT INTO Room (CategoryId, Status)
               VALUES (@CategoryId,  @Status);
            END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE addroom";

            migrationBuilder.Sql(sp);
        }
    }
}
