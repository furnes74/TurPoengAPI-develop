using Microsoft.EntityFrameworkCore.Migrations;

namespace Db.Migrations
{
    public partial class UpdatedPersonWithPhoneAndVisibleToOthers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isVisibleToOthers",
                table: "Person",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "phoneNumber",
                table: "Person",
                maxLength: 11,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isVisibleToOthers",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "phoneNumber",
                table: "Person");
        }
    }
}
