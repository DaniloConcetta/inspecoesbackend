﻿// <auto-generated />
using System;
using Inspecoes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inspecoes.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221106001918_plural")]
    partial class plural
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Inspecoes.Models.GrupoPergunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2")
                        .HasComment("Data atualização");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasComment("Data Cadastro");

                    b.Property<string>("Descricao")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Observacao")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("GruposPerguntas");
                });

            modelBuilder.Entity("Inspecoes.Models.GrupoPerguntaGrupoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2")
                        .HasComment("Data atualização");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasComment("Data Cadastro");

                    b.Property<int>("GrupoPerguntaId")
                        .HasColumnType("int");

                    b.Property<int>("GrupoProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrupoPerguntaId");

                    b.HasIndex("GrupoProdutoId");

                    b.ToTable("GrupoPerguntaGrupoProdutos");
                });

            modelBuilder.Entity("Inspecoes.Models.GrupoPerguntaPergunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2")
                        .HasComment("Data atualização");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasComment("Data Cadastro");

                    b.Property<int>("GrupoPerguntaId")
                        .HasColumnType("int");

                    b.Property<int>("PerguntaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrupoPerguntaId");

                    b.HasIndex("PerguntaId");

                    b.ToTable("GrupoPerguntaPerguntas");
                });

            modelBuilder.Entity("Inspecoes.Models.GrupoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2")
                        .HasComment("Data atualização");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasComment("Data Cadastro");

                    b.Property<string>("Descricao")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("GruposProdutos");
                });

            modelBuilder.Entity("Inspecoes.Models.Pergunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AcaoNao")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("AcaoSim")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2")
                        .HasComment("Data atualização");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasComment("Data Cadastro");

                    b.Property<string>("Descricao")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("LaudoFinal")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("TipoPerguntaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoPerguntaId");

                    b.ToTable("Perguntas");
                });

            modelBuilder.Entity("Inspecoes.Models.TipoPergunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2")
                        .HasComment("Data atualização");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasComment("Data Cadastro");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("TiposPerguntas");
                });

            modelBuilder.Entity("Inspecoes.Models.GrupoPerguntaGrupoProduto", b =>
                {
                    b.HasOne("Inspecoes.Models.GrupoPergunta", "GrupoPergunta")
                        .WithMany("GrupoPerguntaGruposProdutos")
                        .HasForeignKey("GrupoPerguntaId")
                        .IsRequired();

                    b.HasOne("Inspecoes.Models.GrupoProduto", "GrupoProduto")
                        .WithMany("GruposPerguntas")
                        .HasForeignKey("GrupoProdutoId")
                        .IsRequired();

                    b.Navigation("GrupoPergunta");

                    b.Navigation("GrupoProduto");
                });

            modelBuilder.Entity("Inspecoes.Models.GrupoPerguntaPergunta", b =>
                {
                    b.HasOne("Inspecoes.Models.GrupoPergunta", "GrupoPergunta")
                        .WithMany("GrupoPerguntaPerguntas")
                        .HasForeignKey("GrupoPerguntaId")
                        .IsRequired();

                    b.HasOne("Inspecoes.Models.Pergunta", "Pergunta")
                        .WithMany("GruposPerguntas")
                        .HasForeignKey("PerguntaId")
                        .IsRequired();

                    b.Navigation("GrupoPergunta");

                    b.Navigation("Pergunta");
                });

            modelBuilder.Entity("Inspecoes.Models.Pergunta", b =>
                {
                    b.HasOne("Inspecoes.Models.TipoPergunta", "TipoPergunta")
                        .WithMany()
                        .HasForeignKey("TipoPerguntaId");

                    b.Navigation("TipoPergunta");
                });

            modelBuilder.Entity("Inspecoes.Models.GrupoPergunta", b =>
                {
                    b.Navigation("GrupoPerguntaGruposProdutos");

                    b.Navigation("GrupoPerguntaPerguntas");
                });

            modelBuilder.Entity("Inspecoes.Models.GrupoProduto", b =>
                {
                    b.Navigation("GruposPerguntas");
                });

            modelBuilder.Entity("Inspecoes.Models.Pergunta", b =>
                {
                    b.Navigation("GruposPerguntas");
                });
#pragma warning restore 612, 618
        }
    }
}
