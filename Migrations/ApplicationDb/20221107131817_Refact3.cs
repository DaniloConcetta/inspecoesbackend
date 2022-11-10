﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspecoes.Migrations.ApplicationDb
{
    public partial class Refact3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "GruposPerguntas",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "GruposPerguntas");
        }
    }
}