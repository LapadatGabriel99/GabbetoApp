using Microsoft.EntityFrameworkCore.Migrations;

namespace Gabbetto.Word.Web.Server.Migrations
{
    public partial class AddedTheWebSocketDataModelsAndDecoratedThem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    User = table.Column<string>(nullable: false),
                    ConnectionId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupClients",
                columns: table => new
                {
                    WebSocketClientId = table.Column<string>(nullable: false),
                    WebSocketGroupId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupClients", x => new { x.WebSocketClientId, x.WebSocketGroupId });
                    table.ForeignKey(
                        name: "FK_GroupClients_Clients_WebSocketClientId",
                        column: x => x.WebSocketClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupClients_Groups_WebSocketGroupId",
                        column: x => x.WebSocketGroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupClients_WebSocketGroupId",
                table: "GroupClients",
                column: "WebSocketGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupClients");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
