using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspecoes.Migrations
{
    public partial class refact2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Op");
        }
    }
}
