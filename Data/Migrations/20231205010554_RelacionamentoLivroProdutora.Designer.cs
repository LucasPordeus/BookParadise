﻿// <auto-generated />
using System;
using BookParadise.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookParadise.Data.Migrations
{
    [DbContext(typeof(LivroDbContext))]
    [Migration("20231205010554_RelacionamentoLivroProdutora")]
    partial class RelacionamentoLivroProdutora
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookParadise.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("BookParadise.Models.Livro", b =>
                {
                    b.Property<int>("LivroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LivroId"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EntregaExpressa")
                        .HasColumnType("bit");

                    b.Property<string>("ImagemUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<int?>("ProdutoraId")
                        .HasColumnType("int");

                    b.HasKey("LivroId");

                    b.HasIndex("ProdutoraId");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("BookParadise.Models.Produtora", b =>
                {
                    b.Property<int>("ProdutoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoraId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProdutoraId");

                    b.ToTable("Produtora");
                });

            modelBuilder.Entity("CategoriaLivro", b =>
                {
                    b.Property<int>("CategoriasCategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("LivrosLivroId")
                        .HasColumnType("int");

                    b.HasKey("CategoriasCategoriaId", "LivrosLivroId");

                    b.HasIndex("LivrosLivroId");

                    b.ToTable("CategoriaLivro");
                });

            modelBuilder.Entity("BookParadise.Models.Livro", b =>
                {
                    b.HasOne("BookParadise.Models.Produtora", null)
                        .WithMany("Livros")
                        .HasForeignKey("ProdutoraId");
                });

            modelBuilder.Entity("CategoriaLivro", b =>
                {
                    b.HasOne("BookParadise.Models.Categoria", null)
                        .WithMany()
                        .HasForeignKey("CategoriasCategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookParadise.Models.Livro", null)
                        .WithMany()
                        .HasForeignKey("LivrosLivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookParadise.Models.Produtora", b =>
                {
                    b.Navigation("Livros");
                });
#pragma warning restore 612, 618
        }
    }
}
