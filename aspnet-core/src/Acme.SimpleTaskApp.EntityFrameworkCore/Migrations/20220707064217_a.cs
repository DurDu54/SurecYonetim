using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.SimpleTaskApp.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjeId",
                table: "AbpUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TargetNotifiers",
                table: "AbpUserNotifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TargetNotifiers",
                table: "AbpNotifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Proje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    BaslamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MusteriId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Proje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proje_Customers_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Gorevler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GorevAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GorevTanimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    DeveloperId = table.Column<long>(type: "bigint", nullable: true),
                    ProjeId = table.Column<int>(type: "int", nullable: true),
                    BaslamaZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_Gorevler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gorevler_AbpUsers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gorevler_Proje_ProjeId",
                        column: x => x.ProjeId,
                        principalTable: "Proje",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_ProjeId",
                table: "AbpUsers",
                column: "ProjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Gorevler_DeveloperId",
                table: "Gorevler",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Gorevler_ProjeId",
                table: "Gorevler",
                column: "ProjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Proje_MusteriId",
                table: "Proje",
                column: "MusteriId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Proje_ProjeId",
                table: "AbpUsers",
                column: "ProjeId",
                principalTable: "Proje",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Proje_ProjeId",
                table: "AbpUsers");

            migrationBuilder.DropTable(
                name: "Gorevler");

            migrationBuilder.DropTable(
                name: "Proje");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_ProjeId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "ProjeId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "TargetNotifiers",
                table: "AbpUserNotifications");

            migrationBuilder.DropColumn(
                name: "TargetNotifiers",
                table: "AbpNotifications");
        }
    }
}
