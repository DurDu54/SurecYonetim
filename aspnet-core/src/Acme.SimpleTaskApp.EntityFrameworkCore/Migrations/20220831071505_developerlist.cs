using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.SimpleTaskApp.Migrations
{
    public partial class developerlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Proje_ProjeId",
                table: "Developers");

            migrationBuilder.DropIndex(
                name: "IX_Developers_ProjeId",
                table: "Developers");

            migrationBuilder.AddColumn<string>(
                name: "DeveloperName",
                table: "Gorevler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeveloperProje",
                columns: table => new
                {
                    DeveloperlarId = table.Column<int>(type: "int", nullable: false),
                    ProjelerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperProje", x => new { x.DeveloperlarId, x.ProjelerId });
                    table.ForeignKey(
                        name: "FK_DeveloperProje_Developers_DeveloperlarId",
                        column: x => x.DeveloperlarId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperProje_Proje_ProjelerId",
                        column: x => x.ProjelerId,
                        principalTable: "Proje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperProje_ProjelerId",
                table: "DeveloperProje",
                column: "ProjelerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperProje");

            migrationBuilder.DropColumn(
                name: "DeveloperName",
                table: "Gorevler");

            migrationBuilder.CreateIndex(
                name: "IX_Developers_ProjeId",
                table: "Developers",
                column: "ProjeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_Proje_ProjeId",
                table: "Developers",
                column: "ProjeId",
                principalTable: "Proje",
                principalColumn: "Id");
        }
    }
}
