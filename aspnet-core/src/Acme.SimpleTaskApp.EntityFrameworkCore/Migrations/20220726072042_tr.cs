using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.SimpleTaskApp.Migrations
{
    public partial class tr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proje_Customers_MusteriId",
                table: "Proje");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.AddColumn<DateTime>(
                name: "MusteriBitisTarihi",
                table: "Proje",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iletisim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Musteriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musteriler_AbpUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_UserId1",
                table: "Musteriler",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Proje_Musteriler_MusteriId",
                table: "Proje",
                column: "MusteriId",
                principalTable: "Musteriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proje_Musteriler_MusteriId",
                table: "Proje");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropColumn(
                name: "MusteriBitisTarihi",
                table: "Proje");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AbpUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId1",
                table: "Customers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Proje_Customers_MusteriId",
                table: "Proje",
                column: "MusteriId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
