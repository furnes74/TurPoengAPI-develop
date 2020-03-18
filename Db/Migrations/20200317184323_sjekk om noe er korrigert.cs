using Microsoft.EntityFrameworkCore.Migrations;

namespace Db.Migrations
{
    public partial class sjekkomnoeerkorrigert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Person",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "isVisibleToOthers",
                table: "Person",
                newName: "IsVisibleToOthers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Person",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "IsVisibleToOthers",
                table: "Person",
                newName: "isVisibleToOthers");
        }
    }
}
