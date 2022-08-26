using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.SimpleTaskApp.Migrations
{
    public partial class developerIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_ProjeYoneticisi_projeYoneticisiId",
                table: "Developers");

            migrationBuilder.DropForeignKey(
                name: "FK_Gorevler_Developers_DeveloperId",
                table: "Gorevler");

            migrationBuilder.DropIndex(
                name: "IX_Developers_projeYoneticisiId",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "projeYoneticisiId",
                table: "Developers");

            migrationBuilder.AlterColumn<int>(
                name: "DeveloperId",
                table: "Gorevler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Developers_YoneticiId",
                table: "Developers",
                column: "YoneticiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_ProjeYoneticisi_YoneticiId",
                table: "Developers",
                column: "YoneticiId",
                principalTable: "ProjeYoneticisi",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gorevler_Developers_DeveloperId",
                table: "Gorevler",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_ProjeYoneticisi_YoneticiId",
                table: "Developers");

            migrationBuilder.DropForeignKey(
                name: "FK_Gorevler_Developers_DeveloperId",
                table: "Gorevler");

            migrationBuilder.DropIndex(
                name: "IX_Developers_YoneticiId",
                table: "Developers");

            migrationBuilder.AlterColumn<int>(
                name: "DeveloperId",
                table: "Gorevler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "projeYoneticisiId",
                table: "Developers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Developers_projeYoneticisiId",
                table: "Developers",
                column: "projeYoneticisiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_ProjeYoneticisi_projeYoneticisiId",
                table: "Developers",
                column: "projeYoneticisiId",
                principalTable: "ProjeYoneticisi",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gorevler_Developers_DeveloperId",
                table: "Gorevler",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
