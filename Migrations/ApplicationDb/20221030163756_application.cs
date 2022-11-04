using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspecoes.Migrations.ApplicationDb
{
    public partial class application : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GruposPerguntas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Observacao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data Cadastro"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposPerguntas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GruposProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data Cadastro"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposProdutos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposPerguntas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data Cadastro"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPerguntas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoPerguntaGrupoProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrupoProdutoId = table.Column<int>(type: "int", nullable: false),
                    GrupoPerguntaId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data Cadastro"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoPerguntaGrupoProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrupoPerguntaGrupoProduto_GruposPerguntas_GrupoPerguntaId",
                        column: x => x.GrupoPerguntaId,
                        principalTable: "GruposPerguntas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GrupoPerguntaGrupoProduto_GruposProdutos_GrupoProdutoId",
                        column: x => x.GrupoProdutoId,
                        principalTable: "GruposProdutos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Perguntas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    AcaoSim = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    AcaoNao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    LaudoFinal = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    TipoPerguntaId = table.Column<int>(type: "int", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data Cadastro"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perguntas_TiposPerguntas_TipoPerguntaId",
                        column: x => x.TipoPerguntaId,
                        principalTable: "TiposPerguntas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GrupoPerguntaPergunta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerguntaId = table.Column<int>(type: "int", nullable: false),
                    GrupoPerguntaId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data Cadastro"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoPerguntaPergunta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrupoPerguntaPergunta_GruposPerguntas_GrupoPerguntaId",
                        column: x => x.GrupoPerguntaId,
                        principalTable: "GruposPerguntas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GrupoPerguntaPergunta_Perguntas_PerguntaId",
                        column: x => x.PerguntaId,
                        principalTable: "Perguntas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrupoPerguntaGrupoProduto_GrupoPerguntaId",
                table: "GrupoPerguntaGrupoProduto",
                column: "GrupoPerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoPerguntaGrupoProduto_GrupoProdutoId",
                table: "GrupoPerguntaGrupoProduto",
                column: "GrupoProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoPerguntaPergunta_GrupoPerguntaId",
                table: "GrupoPerguntaPergunta",
                column: "GrupoPerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoPerguntaPergunta_PerguntaId",
                table: "GrupoPerguntaPergunta",
                column: "PerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_TipoPerguntaId",
                table: "Perguntas",
                column: "TipoPerguntaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrupoPerguntaGrupoProduto");

            migrationBuilder.DropTable(
                name: "GrupoPerguntaPergunta");

            migrationBuilder.DropTable(
                name: "GruposProdutos");

            migrationBuilder.DropTable(
                name: "GruposPerguntas");

            migrationBuilder.DropTable(
                name: "Perguntas");

            migrationBuilder.DropTable(
                name: "TiposPerguntas");
        }
    }
}
