using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspecoes.Migrations.ApplicationDb
{
    public partial class Refact4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InspecaoItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sim = table.Column<bool>(type: "bit", nullable: true),
                    Nao = table.Column<bool>(type: "bit", nullable: true),
                    Descritivo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    PerguntaId = table.Column<int>(type: "int", nullable: true),
                    PerguntaDescricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    InspecaoId = table.Column<int>(type: "int", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data Cadastro"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspecaoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspecaoItem_Inspecao_InspecaoId",
                        column: x => x.InspecaoId,
                        principalTable: "Inspecao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspecaoItem_Perguntas_PerguntaId",
                        column: x => x.PerguntaId,
                        principalTable: "Perguntas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspecaoItem_InspecaoId",
                table: "InspecaoItem",
                column: "InspecaoId");

            migrationBuilder.CreateIndex(
                name: "IX_InspecaoItem_PerguntaId",
                table: "InspecaoItem",
                column: "PerguntaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspecaoItem");
        }
    }
}
