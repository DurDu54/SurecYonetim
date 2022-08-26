using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.SimpleTaskApp.Migrations
{
    public partial class developerModelMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjeId",
                table: "Developers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YoneticiId",
                table: "Developers",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Proje_ProjeId",
                table: "Developers");

            migrationBuilder.DropIndex(
                name: "IX_Developers_ProjeId",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "ProjeId",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "YoneticiId",
                table: "Developers");
        }
    }
}
