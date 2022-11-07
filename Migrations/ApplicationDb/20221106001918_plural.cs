using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspecoes.Migrations.ApplicationDb
{
    public partial class plural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrupoPerguntaGrupoProduto_GruposPerguntas_GrupoPerguntaId",
                table: "GrupoPerguntaGrupoProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoPerguntaGrupoProduto_GruposProdutos_GrupoProdutoId",
                table: "GrupoPerguntaGrupoProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoPerguntaPergunta_GruposPerguntas_GrupoPerguntaId",
                table: "GrupoPerguntaPergunta");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoPerguntaPergunta_Perguntas_PerguntaId",
                table: "GrupoPerguntaPergunta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrupoPerguntaPergunta",
                table: "GrupoPerguntaPergunta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrupoPerguntaGrupoProduto",
                table: "GrupoPerguntaGrupoProduto");

            migrationBuilder.RenameTable(
                name: "GrupoPerguntaPergunta",
                newName: "GrupoPerguntaPerguntas");

            migrationBuilder.RenameTable(
                name: "GrupoPerguntaGrupoProduto",
                newName: "GrupoPerguntaGrupoProdutos");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoPerguntaPergunta_PerguntaId",
                table: "GrupoPerguntaPerguntas",
                newName: "IX_GrupoPerguntaPerguntas_PerguntaId");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoPerguntaPergunta_GrupoPerguntaId",
                table: "GrupoPerguntaPerguntas",
                newName: "IX_GrupoPerguntaPerguntas_GrupoPerguntaId");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoPerguntaGrupoProduto_GrupoProdutoId",
                table: "GrupoPerguntaGrupoProdutos",
                newName: "IX_GrupoPerguntaGrupoProdutos_GrupoProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoPerguntaGrupoProduto_GrupoPerguntaId",
                table: "GrupoPerguntaGrupoProdutos",
                newName: "IX_GrupoPerguntaGrupoProdutos_GrupoPerguntaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrupoPerguntaPerguntas",
                table: "GrupoPerguntaPerguntas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrupoPerguntaGrupoProdutos",
                table: "GrupoPerguntaGrupoProdutos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoPerguntaGrupoProdutos_GruposPerguntas_GrupoPerguntaId",
                table: "GrupoPerguntaGrupoProdutos",
                column: "GrupoPerguntaId",
                principalTable: "GruposPerguntas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoPerguntaGrupoProdutos_GruposProdutos_GrupoProdutoId",
                table: "GrupoPerguntaGrupoProdutos",
                column: "GrupoProdutoId",
                principalTable: "GruposProdutos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoPerguntaPerguntas_GruposPerguntas_GrupoPerguntaId",
                table: "GrupoPerguntaPerguntas",
                column: "GrupoPerguntaId",
                principalTable: "GruposPerguntas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoPerguntaPerguntas_Perguntas_PerguntaId",
                table: "GrupoPerguntaPerguntas",
                column: "PerguntaId",
                principalTable: "Perguntas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrupoPerguntaGrupoProdutos_GruposPerguntas_GrupoPerguntaId",
                table: "GrupoPerguntaGrupoProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoPerguntaGrupoProdutos_GruposProdutos_GrupoProdutoId",
                table: "GrupoPerguntaGrupoProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoPerguntaPerguntas_GruposPerguntas_GrupoPerguntaId",
                table: "GrupoPerguntaPerguntas");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoPerguntaPerguntas_Perguntas_PerguntaId",
                table: "GrupoPerguntaPerguntas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrupoPerguntaPerguntas",
                table: "GrupoPerguntaPerguntas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrupoPerguntaGrupoProdutos",
                table: "GrupoPerguntaGrupoProdutos");

            migrationBuilder.RenameTable(
                name: "GrupoPerguntaPerguntas",
                newName: "GrupoPerguntaPergunta");

            migrationBuilder.RenameTable(
                name: "GrupoPerguntaGrupoProdutos",
                newName: "GrupoPerguntaGrupoProduto");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoPerguntaPerguntas_PerguntaId",
                table: "GrupoPerguntaPergunta",
                newName: "IX_GrupoPerguntaPergunta_PerguntaId");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoPerguntaPerguntas_GrupoPerguntaId",
                table: "GrupoPerguntaPergunta",
                newName: "IX_GrupoPerguntaPergunta_GrupoPerguntaId");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoPerguntaGrupoProdutos_GrupoProdutoId",
                table: "GrupoPerguntaGrupoProduto",
                newName: "IX_GrupoPerguntaGrupoProduto_GrupoProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoPerguntaGrupoProdutos_GrupoPerguntaId",
                table: "GrupoPerguntaGrupoProduto",
                newName: "IX_GrupoPerguntaGrupoProduto_GrupoPerguntaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrupoPerguntaPergunta",
                table: "GrupoPerguntaPergunta",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrupoPerguntaGrupoProduto",
                table: "GrupoPerguntaGrupoProduto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoPerguntaGrupoProduto_GruposPerguntas_GrupoPerguntaId",
                table: "GrupoPerguntaGrupoProduto",
                column: "GrupoPerguntaId",
                principalTable: "GruposPerguntas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoPerguntaGrupoProduto_GruposProdutos_GrupoProdutoId",
                table: "GrupoPerguntaGrupoProduto",
                column: "GrupoProdutoId",
                principalTable: "GruposProdutos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoPerguntaPergunta_GruposPerguntas_GrupoPerguntaId",
                table: "GrupoPerguntaPergunta",
                column: "GrupoPerguntaId",
                principalTable: "GruposPerguntas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoPerguntaPergunta_Perguntas_PerguntaId",
                table: "GrupoPerguntaPergunta",
                column: "PerguntaId",
                principalTable: "Perguntas",
                principalColumn: "Id");
        }
    }
}
