using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reddit.Migrations
{
    /// <inheritdoc />
    public partial class addedDBset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Community_Users_OwnerId",
                table: "Community");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityUser_Community_SubscribedCommunitiesCommunityId",
                table: "CommunityUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Community_CommunityId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Community",
                table: "Community");

            migrationBuilder.RenameTable(
                name: "Community",
                newName: "Communities");

            migrationBuilder.RenameIndex(
                name: "IX_Community_OwnerId",
                table: "Communities",
                newName: "IX_Communities_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Communities",
                table: "Communities",
                column: "CommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Communities_Users_OwnerId",
                table: "Communities",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityUser_Communities_SubscribedCommunitiesCommunityId",
                table: "CommunityUser",
                column: "SubscribedCommunitiesCommunityId",
                principalTable: "Communities",
                principalColumn: "CommunityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Communities_CommunityId",
                table: "Posts",
                column: "CommunityId",
                principalTable: "Communities",
                principalColumn: "CommunityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communities_Users_OwnerId",
                table: "Communities");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityUser_Communities_SubscribedCommunitiesCommunityId",
                table: "CommunityUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Communities_CommunityId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Communities",
                table: "Communities");

            migrationBuilder.RenameTable(
                name: "Communities",
                newName: "Community");

            migrationBuilder.RenameIndex(
                name: "IX_Communities_OwnerId",
                table: "Community",
                newName: "IX_Community_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Community",
                table: "Community",
                column: "CommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Community_Users_OwnerId",
                table: "Community",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityUser_Community_SubscribedCommunitiesCommunityId",
                table: "CommunityUser",
                column: "SubscribedCommunitiesCommunityId",
                principalTable: "Community",
                principalColumn: "CommunityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Community_CommunityId",
                table: "Posts",
                column: "CommunityId",
                principalTable: "Community",
                principalColumn: "CommunityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
