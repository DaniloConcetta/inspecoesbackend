using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspecoes.Migrations.ApplicationDb
{
    public partial class Refact7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "InspecaoItem",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Inspecao",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "InspecaoItem");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Inspecao");
        }
    }
}
