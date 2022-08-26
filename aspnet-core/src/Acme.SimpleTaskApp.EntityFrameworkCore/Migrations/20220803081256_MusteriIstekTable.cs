using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.SimpleTaskApp.Migrations
{
    public partial class MusteriIstekTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "MusteriIstek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeId = table.Column<int>(type: "int", nullable: false),
                    MusteriIstekId = table.Column<int>(type: "int", nullable: false),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    Istek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaslangicTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegistirmeTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriIstek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusteriIstek_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MusteriIstek_Proje_ProjeId",
                        column: x => x.ProjeId,
                        principalTable: "Proje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusteriIstek_MusteriId",
                table: "MusteriIstek",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_MusteriIstek_ProjeId",
                table: "MusteriIstek",
                column: "ProjeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MusteriTalepler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    ProjeId = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaslamaTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    Talep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Test = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriTalepler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusteriTalepler_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MusteriTalepler_Proje_ProjeId",
                        column: x => x.ProjeId,
                        principalTable: "Proje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusteriTalepler_MusteriId",
                table: "MusteriTalepler",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_MusteriTalepler_ProjeId",
                table: "MusteriTalepler",
                column: "ProjeId");
        }
    }
}
