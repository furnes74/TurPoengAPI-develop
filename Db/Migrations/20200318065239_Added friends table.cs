using Microsoft.EntityFrameworkCore.Migrations;

namespace Db.Migrations
{
    public partial class Addedfriendstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyFriend",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    FriendId = table.Column<int>(nullable: false),
                    Accepted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyFriend", x => new { x.PersonId, x.FriendId });
                    table.ForeignKey(
                        name: "FK_MyFriend_Person_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MyFriend_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyFriend_FriendId",
                table: "MyFriend",
                column: "FriendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyFriend");
        }
    }
}
