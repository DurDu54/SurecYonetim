using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.SimpleTaskApp.Migrations
{
    public partial class qwerb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AbpUsers_UserId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "Customers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId1",
                table: "Customers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AbpUsers_UserId1",
                table: "Customers",
                column: "UserId1",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AbpUsers_UserId1",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Customers");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Customers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AbpUsers_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }
    }
}
