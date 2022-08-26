using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.SimpleTaskApp.Migrations
{
    public partial class userIdToMusteriModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musteriler_AbpUsers_UserId",
                table: "Musteriler");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Musteriler",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Musteriler_AbpUsers_UserId",
                table: "Musteriler",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musteriler_AbpUsers_UserId",
                table: "Musteriler");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Musteriler",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Musteriler_AbpUsers_UserId",
                table: "Musteriler",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }
    }
}
