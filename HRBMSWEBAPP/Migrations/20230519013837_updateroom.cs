using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRBMSWEBAPP.Migrations
{
    public partial class updateroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE OR ALTER PROCEDURE updateroom
            @roomId INT,
            @Status BIT,
            @CategoryId INT
            AS
            BEGIN
               UPDATE Room 
               SET CategoryId = @CategoryId,
                   Status = @Status
               WHERE Id = @roomId;
            END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE updateroom";

            migrationBuilder.Sql(sp);
        }
    }
}
