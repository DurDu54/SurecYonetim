using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.SimpleTaskApp.Migrations
{
    public partial class musterilerMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gorevler_AbpUsers_DeveloperId1",
                table: "Gorevler");

            migrationBuilder.DropForeignKey(
                name: "FK_Gorevler_Proje_ProjeID",
                table: "Gorevler");

            migrationBuilder.DropForeignKey(
                name: "FK_Musteriler_AbpUsers_UserId1",
                table: "Musteriler");

            migrationBuilder.DropTable(
                name: "ProjeUser");

            migrationBuilder.DropIndex(
                name: "IX_Musteriler_UserId1",
                table: "Musteriler");

            migrationBuilder.DropIndex(
                name: "IX_Gorevler_DeveloperId1",
                table: "Gorevler");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Musteriler");

            migrationBuilder.DropColumn(
                name: "DeveloperId1",
                table: "Gorevler");

            migrationBuilder.RenameColumn(
                name: "ProjeID",
                table: "Gorevler",
                newName: "ProjeId");

            migrationBuilder.RenameIndex(
                name: "IX_Gorevler_ProjeID",
                table: "Gorevler",
                newName: "IX_Gorevler_ProjeId");

            migrationBuilder.AddColumn<int>(
                name: "projeYoneticisiId",
                table: "Proje",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Musteriler",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjeId",
                table: "Gorevler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                table: "Gorevler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjeYoneticisi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeYoneticisiId = table.Column<long>(type: "bigint", nullable: false),
                    ProjeYoneticisiAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_ProjeYoneticisi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjeYoneticisi_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeveloperSide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeveloperCommits = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    projeYoneticisiId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Developers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Developers_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Developers_ProjeYoneticisi_projeYoneticisiId",
                        column: x => x.projeYoneticisiId,
                        principalTable: "ProjeYoneticisi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proje_projeYoneticisiId",
                table: "Proje",
                column: "projeYoneticisiId");

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_UserId",
                table: "Musteriler",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Gorevler_DeveloperId",
                table: "Gorevler",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Gorevler_projeYoneticisiId",
                table: "Gorevler",
                column: "projeYoneticisiId");

            migrationBuilder.CreateIndex(
                name: "IX_Developers_projeYoneticisiId",
                table: "Developers",
                column: "projeYoneticisiId");

            migrationBuilder.CreateIndex(
                name: "IX_Developers_UserId",
                table: "Developers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeYoneticisi_UserId",
                table: "ProjeYoneticisi",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gorevler_Developers_DeveloperId",
                table: "Gorevler",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gorevler_Proje_ProjeId",
                table: "Gorevler",
                column: "ProjeId",
                principalTable: "Proje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gorevler_ProjeYoneticisi_projeYoneticisiId",
                table: "Gorevler",
                column: "projeYoneticisiId",
                principalTable: "ProjeYoneticisi",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musteriler_AbpUsers_UserId",
                table: "Musteriler",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proje_ProjeYoneticisi_projeYoneticisiId",
                table: "Proje",
                column: "projeYoneticisiId",
                principalTable: "ProjeYoneticisi",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gorevler_Developers_DeveloperId",
                table: "Gorevler");

            migrationBuilder.DropForeignKey(
                name: "FK_Gorevler_Proje_ProjeId",
                table: "Gorevler");

            migrationBuilder.DropForeignKey(
                name: "FK_Gorevler_ProjeYoneticisi_projeYoneticisiId",
                table: "Gorevler");

            migrationBuilder.DropForeignKey(
                name: "FK_Musteriler_AbpUsers_UserId",
                table: "Musteriler");

            migrationBuilder.DropForeignKey(
                name: "FK_Proje_ProjeYoneticisi_projeYoneticisiId",
                table: "Proje");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "ProjeYoneticisi");

            migrationBuilder.DropIndex(
                name: "IX_Proje_projeYoneticisiId",
                table: "Proje");

            migrationBuilder.DropIndex(
                name: "IX_Musteriler_UserId",
                table: "Musteriler");

            migrationBuilder.DropIndex(
                name: "IX_Gorevler_DeveloperId",
                table: "Gorevler");

            migrationBuilder.DropIndex(
                name: "IX_Gorevler_projeYoneticisiId",
                table: "Gorevler");

            migrationBuilder.DropColumn(
                name: "projeYoneticisiId",
                table: "Proje");

            migrationBuilder.DropColumn(
                name: "projeYoneticisiId",
                table: "Gorevler");

            migrationBuilder.RenameColumn(
                name: "ProjeId",
                table: "Gorevler",
                newName: "ProjeID");

            migrationBuilder.RenameIndex(
                name: "IX_Gorevler_ProjeId",
                table: "Gorevler",
                newName: "IX_Gorevler_ProjeID");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Musteriler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "Musteriler",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjeID",
                table: "Gorevler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DeveloperId",
                table: "Gorevler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "DeveloperId1",
                table: "Gorevler",
                type: "bigint",
                nullable: true);

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
                name: "IX_Musteriler_UserId1",
                table: "Musteriler",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Gorevler_DeveloperId1",
                table: "Gorevler",
                column: "DeveloperId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeUser_ProjelerId",
                table: "ProjeUser",
                column: "ProjelerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gorevler_AbpUsers_DeveloperId1",
                table: "Gorevler",
                column: "DeveloperId1",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gorevler_Proje_ProjeID",
                table: "Gorevler",
                column: "ProjeID",
                principalTable: "Proje",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musteriler_AbpUsers_UserId1",
                table: "Musteriler",
                column: "UserId1",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }
    }
}
