using Microsoft.EntityFrameworkCore.Migrations;

namespace Db.Migrations
{
    public partial class Utvidetpost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Post",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SuggestedByPersonId",
                table: "Post",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_SuggestedByPersonId",
                table: "Post",
                column: "SuggestedByPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Person_SuggestedByPersonId",
                table: "Post",
                column: "SuggestedByPersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Person_SuggestedByPersonId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_SuggestedByPersonId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "SuggestedByPersonId",
                table: "Post");
        }
    }
}
