﻿// <auto-generated />
using System;
using Inspecoes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inspecoes.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221021110535_Tabelas")]
    partial class Tabelas
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
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observacao")
                        .IsRequired()
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
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("GrupoPerguntaId")
                        .HasColumnType("int");

                    b.Property<int>("GrupoProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrupoPerguntaId");

                    b.HasIndex("GrupoProdutoId");

                    b.ToTable("GrupoPerguntaGrupoProduto");
                });

            modelBuilder.Entity("Inspecoes.Models.GrupoPerguntaPergunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("GrupoPerguntaId")
                        .HasColumnType("int");

                    b.Property<int>("PerguntaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrupoPerguntaId");

                    b.HasIndex("PerguntaId");

                    b.ToTable("GrupoPerguntaPergunta");
                });

            modelBuilder.Entity("Inspecoes.Models.GrupoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

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
                        .HasColumnType("varchar(100)");

                    b.Property<string>("AcaoSim")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LaudoFinal")
                        .HasColumnType("varchar(100)");

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
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TiposPerguntas");
                });

            modelBuilder.Entity("Inspecoes.Models.GrupoPerguntaGrupoProduto", b =>
                {
                    b.HasOne("Inspecoes.Models.GrupoPergunta", "GrupoPergunta")
                        .WithMany("GruposProdutos")
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
                        .WithMany("Perguntas")
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
                    b.Navigation("GruposProdutos");

                    b.Navigation("Perguntas");
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
