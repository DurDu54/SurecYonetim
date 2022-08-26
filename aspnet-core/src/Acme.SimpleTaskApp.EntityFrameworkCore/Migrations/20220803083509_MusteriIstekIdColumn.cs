using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.SimpleTaskApp.Migrations
{
    public partial class MusteriIstekIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MusteriIstekId",
                table: "MusteriIstek");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MusteriIstekId",
                table: "MusteriIstek",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
