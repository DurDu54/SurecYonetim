using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.SimpleTaskApp.Migrations
{
    public partial class projeYoneticisiMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proje_ProjeYoneticisi_projeYoneticisiId",
                table: "Proje");

            migrationBuilder.RenameColumn(
                name: "projeYoneticisiId",
                table: "Proje",
                newName: "ProjeYoneticisiId");

            migrationBuilder.RenameIndex(
                name: "IX_Proje_projeYoneticisiId",
                table: "Proje",
                newName: "IX_Proje_ProjeYoneticisiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proje_ProjeYoneticisi_ProjeYoneticisiId",
                table: "Proje",
                column: "ProjeYoneticisiId",
                principalTable: "ProjeYoneticisi",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proje_ProjeYoneticisi_ProjeYoneticisiId",
                table: "Proje");

            migrationBuilder.RenameColumn(
                name: "ProjeYoneticisiId",
                table: "Proje",
                newName: "projeYoneticisiId");

            migrationBuilder.RenameIndex(
                name: "IX_Proje_ProjeYoneticisiId",
                table: "Proje",
                newName: "IX_Proje_projeYoneticisiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proje_ProjeYoneticisi_projeYoneticisiId",
                table: "Proje",
                column: "projeYoneticisiId",
                principalTable: "ProjeYoneticisi",
                principalColumn: "Id");
        }
    }
}
