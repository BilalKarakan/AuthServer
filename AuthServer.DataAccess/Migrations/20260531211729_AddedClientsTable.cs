using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthServer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedClientsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<string>(type: "text", maxLength: 100, nullable: false),
                    SecretKey = table.Column<string>(type: "text", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "ClientAudiences",
                columns: table => new
                {
                    ClientId = table.Column<string>(type: "text", maxLength: 100, nullable: false),
                    Audience = table.Column<string>(type: "text", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAudiences", x => new { x.ClientId, x.Audience });
                    table.ForeignKey(
                        name: "FK_ClientAudiences_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientAudiences");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
