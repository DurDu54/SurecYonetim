using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.SimpleTaskApp.Migrations
{
    public partial class GorevBitirmeTarihColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BitirmeZamani",
                table: "Gorevler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BitirmeZamani",
                table: "Gorevler");
        }
    }
}
