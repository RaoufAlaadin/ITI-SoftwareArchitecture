using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DepartementTask.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tickets_departements_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "departements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperTickets",
                columns: table => new
                {
                    developerId = table.Column<int>(type: "int", nullable: false),
                    ticketsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperTickets", x => new { x.developerId, x.ticketsId });
                    table.ForeignKey(
                        name: "FK_DeveloperTickets_developers_developerId",
                        column: x => x.developerId,
                        principalTable: "developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperTickets_tickets_ticketsId",
                        column: x => x.ticketsId,
                        principalTable: "tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "departements",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sales" },
                    { 2, "Marketing" },
                    { 3, "Finance" },
                    { 4, "HR" },
                    { 5, "IT" }
                });

            migrationBuilder.InsertData(
                table: "developers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "John Doe" },
                    { 2, "Jane Smith" },
                    { 3, "Bob Johnson" },
                    { 4, "Emily Davis" },
                    { 5, "David Lee" }
                });

            migrationBuilder.InsertData(
                table: "tickets",
                columns: new[] { "Id", "DepartementId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "This is ticket 1", "Ticket 1" },
                    { 2, 2, "This is ticket 2", "Ticket 2" },
                    { 3, 3, "This is ticket 3", "Ticket 3" },
                    { 4, 4, "This is ticket 4", "Ticket 4" },
                    { 5, 5, "This is ticket 5", "Ticket 5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTickets_ticketsId",
                table: "DeveloperTickets",
                column: "ticketsId");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_DepartementId",
                table: "tickets",
                column: "DepartementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperTickets");

            migrationBuilder.DropTable(
                name: "developers");

            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "departements");
        }
    }
}
