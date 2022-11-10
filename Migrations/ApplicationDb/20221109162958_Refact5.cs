using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspecoes.Migrations.ApplicationDb
{
    public partial class Refact5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LaudoFinal",
                table: "Perguntas",
                newName: "LaudoSim");

            migrationBuilder.AddColumn<string>(
                name: "LaudoNao",
                table: "Perguntas",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LaudoNao",
                table: "Perguntas");

            migrationBuilder.RenameColumn(
                name: "LaudoSim",
                table: "Perguntas",
                newName: "LaudoFinal");
        }
    }
}
