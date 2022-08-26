using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.SimpleTaskApp.Migrations
{
    public partial class yoneticiDuzenleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjeYoneticisiId",
                table: "ProjeYoneticisi");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "ProjeYoneticisi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Iletisim",
                table: "ProjeYoneticisi",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "ProjeYoneticisi");

            migrationBuilder.DropColumn(
                name: "Iletisim",
                table: "ProjeYoneticisi");

            migrationBuilder.AddColumn<long>(
                name: "ProjeYoneticisiId",
                table: "ProjeYoneticisi",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
