using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.SimpleTaskApp.Migrations
{
    public partial class userprojects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Proje_ProjeId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_ProjeId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "ProjeId",
                table: "AbpUsers");

            migrationBuilder.CreateTable(
                name: "ProjeUser",
                columns: table => new
                {
                    DevelopersId = table.Column<long>(type: "bigint", nullable: false),
                    ProjelerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjeUser", x => new { x.DevelopersId, x.ProjelerId });
                    table.ForeignKey(
                        name: "FK_ProjeUser_AbpUsers_DevelopersId",
                        column: x => x.DevelopersId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjeUser_Proje_ProjelerId",
                        column: x => x.ProjelerId,
                        principalTable: "Proje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjeUser_ProjelerId",
                table: "ProjeUser",
                column: "ProjelerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjeUser");

            migrationBuilder.AddColumn<int>(
                name: "ProjeId",
                table: "AbpUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_ProjeId",
                table: "AbpUsers",
                column: "ProjeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Proje_ProjeId",
                table: "AbpUsers",
                column: "ProjeId",
                principalTable: "Proje",
                principalColumn: "Id");
        }
    }
}
