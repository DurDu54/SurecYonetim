using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.SimpleTaskApp.Migrations
{
    public partial class asdr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gorevler_AbpUsers_DeveloperId",
                table: "Gorevler");

            migrationBuilder.DropForeignKey(
                name: "FK_Gorevler_Proje_ProjeId",
                table: "Gorevler");

            migrationBuilder.DropForeignKey(
                name: "FK_Proje_Customers_MusteriId",
                table: "Proje");

            migrationBuilder.DropIndex(
                name: "IX_Gorevler_DeveloperId",
                table: "Gorevler");

            migrationBuilder.DropColumn(
                name: "BitisZamani",
                table: "Gorevler");

            migrationBuilder.DropColumn(
                name: "GorevAdi",
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
                name: "MusteriId",
                table: "Proje",
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
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeveloperId1",
                table: "Gorevler",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gorevler_DeveloperId1",
                table: "Gorevler",
                column: "DeveloperId1");

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
                name: "FK_Proje_Customers_MusteriId",
                table: "Proje",
                column: "MusteriId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gorevler_AbpUsers_DeveloperId1",
                table: "Gorevler");

            migrationBuilder.DropForeignKey(
                name: "FK_Gorevler_Proje_ProjeID",
                table: "Gorevler");

            migrationBuilder.DropForeignKey(
                name: "FK_Proje_Customers_MusteriId",
                table: "Proje");

            migrationBuilder.DropIndex(
                name: "IX_Gorevler_DeveloperId1",
                table: "Gorevler");

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

            migrationBuilder.AlterColumn<int>(
                name: "MusteriId",
                table: "Proje",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "DeveloperId",
                table: "Gorevler",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BitisZamani",
                table: "Gorevler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GorevAdi",
                table: "Gorevler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gorevler_DeveloperId",
                table: "Gorevler",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gorevler_AbpUsers_DeveloperId",
                table: "Gorevler",
                column: "DeveloperId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gorevler_Proje_ProjeId",
                table: "Gorevler",
                column: "ProjeId",
                principalTable: "Proje",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proje_Customers_MusteriId",
                table: "Proje",
                column: "MusteriId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
