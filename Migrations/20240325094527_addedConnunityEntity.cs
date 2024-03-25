using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reddit.Migrations
{
    /// <inheritdoc />
    public partial class addedConnunityEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommunityId",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Community",
                columns: table => new
                {
                    CommunityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Community", x => x.CommunityId);
                    table.ForeignKey(
                        name: "FK_Community_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityUser",
                columns: table => new
                {
                    SubscribedCommunitiesCommunityId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserSubscribersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityUser", x => new { x.SubscribedCommunitiesCommunityId, x.UserSubscribersId });
                    table.ForeignKey(
                        name: "FK_CommunityUser_Community_SubscribedCommunitiesCommunityId",
                        column: x => x.SubscribedCommunitiesCommunityId,
                        principalTable: "Community",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityUser_Users_UserSubscribersId",
                        column: x => x.UserSubscribersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CommunityId",
                table: "Posts",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Community_OwnerId",
                table: "Community",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityUser_UserSubscribersId",
                table: "CommunityUser",
                column: "UserSubscribersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Community_CommunityId",
                table: "Posts",
                column: "CommunityId",
                principalTable: "Community",
                principalColumn: "CommunityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Community_CommunityId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "CommunityUser");

            migrationBuilder.DropTable(
                name: "Community");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CommunityId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CommunityId",
                table: "Posts");
        }
    }
}
