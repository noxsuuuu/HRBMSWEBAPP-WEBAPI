using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRBMSWEBAPP.Migrations
{
    public partial class removedcheckinOut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CheckIn",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "Invoice");

            }

       
    }
}
