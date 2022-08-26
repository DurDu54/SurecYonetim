using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.SimpleTaskApp.Migrations
{
    public partial class GorevDeveloperBaglantisi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gorevler_ProjeYoneticisi_projeYoneticisiId",
                table: "Gorevler");

            migrationBuilder.DropIndex(
                name: "IX_Gorevler_projeYoneticisiId",
                table: "Gorevler");

            migrationBuilder.DropColumn(
                name: "projeYoneticisiId",
                table: "Gorevler");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "projeYoneticisiId",
                table: "Gorevler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gorevler_projeYoneticisiId",
                table: "Gorevler",
                column: "projeYoneticisiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gorevler_ProjeYoneticisi_projeYoneticisiId",
                table: "Gorevler",
                column: "projeYoneticisiId",
                principalTable: "ProjeYoneticisi",
                principalColumn: "Id");
        }
    }
}
