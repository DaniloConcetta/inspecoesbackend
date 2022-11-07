using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspecoes.Migrations
{
    public partial class refact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inspecao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: true),
                    StatusInspecaoId = table.Column<int>(type: "int", nullable: true),
                    OpId = table.Column<int>(type: "int", nullable: true),
                    GrupoPerguntaId = table.Column<int>(type: "int", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data Cadastro"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspecao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspecao_GruposPerguntas_GrupoPerguntaId",
                        column: x => x.GrupoPerguntaId,
                        principalTable: "GruposPerguntas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inspecao_Op_OpId",
                        column: x => x.OpId,
                        principalTable: "Op",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inspecao_StatusInspecao_StatusInspecaoId",
                        column: x => x.StatusInspecaoId,
                        principalTable: "StatusInspecao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspecao_GrupoPerguntaId",
                table: "Inspecao",
                column: "GrupoPerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspecao_OpId",
                table: "Inspecao",
                column: "OpId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspecao_StatusInspecaoId",
                table: "Inspecao",
                column: "StatusInspecaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inspecao");
        }
    }
}
