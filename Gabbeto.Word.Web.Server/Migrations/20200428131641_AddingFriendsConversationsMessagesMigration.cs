using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gabbetto.Word.Web.Server.Migrations
{
    public partial class AddingFriendsConversationsMessagesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    User1 = table.Column<string>(nullable: false),
                    User2 = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendshipStatuses",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    Description = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendshipStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConversationId = table.Column<string>(nullable: true),
                    From = table.Column<string>(maxLength: 256, nullable: false),
                    To = table.Column<string>(maxLength: 256, nullable: false),
                    Content = table.Column<string>(maxLength: 2048, nullable: false),
                    SentByMe = table.Column<bool>(nullable: false),
                    SentDate = table.Column<DateTime>(nullable: false),
                    ReadTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    RequestedBy = table.Column<string>(nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    AcceptDate = table.Column<DateTime>(nullable: false),
                    RequestedTo = table.Column<string>(nullable: false),
                    StatusId = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friendships_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friendships_FriendshipStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "FriendshipStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friendships_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_Name",
                table: "Conversations",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_UserId",
                table: "Conversations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_ApplicationUserId",
                table: "Friendships",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_StatusId",
                table: "Friendships",
                column: "StatusId",
                unique: true,
                filter: "[StatusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_UserId",
                table: "Friendships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ConversationId",
                table: "Messages",
                column: "ConversationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "FriendshipStatuses");

            migrationBuilder.DropTable(
                name: "Conversations");
        }
    }
}
