using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Db.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BagesName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    Picture = table.Column<byte[]>(nullable: true),
                    Birth = table.Column<DateTime>(nullable: false),
                    showAsActiveUser = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 4, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 255, nullable: false),
                    Password = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CallingName = table.Column<string>(maxLength: 50, nullable: true),
                    PostHeight = table.Column<int>(nullable: false),
                    PostStartHeight = table.Column<int>(nullable: false),
                    PostWalkDistance = table.Column<int>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    DefaultPoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Idrettslag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Approved = table.Column<bool>(nullable: false),
                    ZipCode = table.Column<string>(maxLength: 4, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 255, nullable: false),
                    AdminId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idrettslag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Idrettslag_Person_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonActive",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    LastActiveTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonActive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonActive_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 400, nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    PrivatePicture = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => new { x.PersonId, x.PostId });
                    table.ForeignKey(
                        name: "FK_Pictures_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pictures_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostVisit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registered = table.Column<DateTime>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostVisit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostVisit_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostVisit_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdrettslagMember",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    IdrettslagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdrettslagMember", x => new { x.PersonId, x.IdrettslagId });
                    table.ForeignKey(
                        name: "FK_IdrettslagMember_Idrettslag_IdrettslagId",
                        column: x => x.IdrettslagId,
                        principalTable: "Idrettslag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IdrettslagMember_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "IdrettslagPost",
                columns: table => new
                {
                    IdrettslagId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    OverridePoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdrettslagPost", x => new { x.PostId, x.IdrettslagId });
                    table.ForeignKey(
                        name: "FK_IdrettslagPost_Idrettslag_IdrettslagId",
                        column: x => x.IdrettslagId,
                        principalTable: "Idrettslag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdrettslagPost_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Idrettslag_AdminId",
                table: "Idrettslag",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_IdrettslagMember_IdrettslagId",
                table: "IdrettslagMember",
                column: "IdrettslagId");

            migrationBuilder.CreateIndex(
                name: "IX_IdrettslagPost_IdrettslagId",
                table: "IdrettslagPost",
                column: "IdrettslagId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonActive_PersonId",
                table: "PersonActive",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_PostId",
                table: "Pictures",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostVisit_PersonId",
                table: "PostVisit",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PostVisit_PostId",
                table: "PostVisit",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Badges");

            migrationBuilder.DropTable(
                name: "IdrettslagMember");

            migrationBuilder.DropTable(
                name: "IdrettslagPost");

            migrationBuilder.DropTable(
                name: "PersonActive");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "PostVisit");

            migrationBuilder.DropTable(
                name: "Idrettslag");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
