using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspecoes.Migrations.ApplicationDb
{
    public partial class inicialAplication : Migration
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
                name: "Op",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opnumero = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    ProdutoCodigo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    ProdutoDescricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ProdutoGrupo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data Cadastro"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Op", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusInspecao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data Cadastro"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusInspecao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposPerguntas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data Cadastro"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data atualização")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPerguntas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoPerguntaGrupoProdutos",
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
                    table.PrimaryKey("PK_GrupoPerguntaGrupoProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrupoPerguntaGrupoProdutos_GruposPerguntas_GrupoPerguntaId",
                        column: x => x.GrupoPerguntaId,
                        principalTable: "GruposPerguntas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GrupoPerguntaGrupoProdutos_GruposProdutos_GrupoProdutoId",
                        column: x => x.GrupoProdutoId,
                        principalTable: "GruposProdutos",
                        principalColumn: "Id");
                });

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
                name: "GrupoPerguntaPerguntas",
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
                    table.PrimaryKey("PK_GrupoPerguntaPerguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrupoPerguntaPerguntas_GruposPerguntas_GrupoPerguntaId",
                        column: x => x.GrupoPerguntaId,
                        principalTable: "GruposPerguntas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GrupoPerguntaPerguntas_Perguntas_PerguntaId",
                        column: x => x.PerguntaId,
                        principalTable: "Perguntas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrupoPerguntaGrupoProdutos_GrupoPerguntaId",
                table: "GrupoPerguntaGrupoProdutos",
                column: "GrupoPerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoPerguntaGrupoProdutos_GrupoProdutoId",
                table: "GrupoPerguntaGrupoProdutos",
                column: "GrupoProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoPerguntaPerguntas_GrupoPerguntaId",
                table: "GrupoPerguntaPerguntas",
                column: "GrupoPerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoPerguntaPerguntas_PerguntaId",
                table: "GrupoPerguntaPerguntas",
                column: "PerguntaId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_TipoPerguntaId",
                table: "Perguntas",
                column: "TipoPerguntaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrupoPerguntaGrupoProdutos");

            migrationBuilder.DropTable(
                name: "GrupoPerguntaPerguntas");

            migrationBuilder.DropTable(
                name: "Inspecao");

            migrationBuilder.DropTable(
                name: "GruposProdutos");

            migrationBuilder.DropTable(
                name: "Perguntas");

            migrationBuilder.DropTable(
                name: "GruposPerguntas");

            migrationBuilder.DropTable(
                name: "Op");

            migrationBuilder.DropTable(
                name: "StatusInspecao");

            migrationBuilder.DropTable(
                name: "TiposPerguntas");
        }
    }
}
