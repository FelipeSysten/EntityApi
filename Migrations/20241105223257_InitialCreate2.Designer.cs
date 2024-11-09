﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplicationApi.Data;

#nullable disable

namespace WebApplicationApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241105223257_InitialCreate2")]
    partial class InitialCreate2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplicationApi.Models.ClienteModel", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdCliente"));

                    b.Property<DateTime>("DataNascimentoCliente")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EmailCliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ItemProdutoIdItemProduto")
                        .HasColumnType("integer");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumeroCliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StatusPedido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdCliente");

                    b.HasIndex("ItemProdutoIdItemProduto");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("WebApplicationApi.Models.ItemProdutoModel", b =>
                {
                    b.Property<int>("IdItemProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdItemProduto"));

                    b.Property<int>("ItemQuantidade")
                        .HasColumnType("integer");

                    b.HasKey("IdItemProduto");

                    b.ToTable("ItemProdutos");
                });

            modelBuilder.Entity("WebApplicationApi.Models.ProdutoModel", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdProduto"));

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TipoProduto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ValorProduto")
                        .HasColumnType("numeric");

                    b.HasKey("IdProduto");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("WebApplicationApi.Models.VinculaModel", b =>
                {
                    b.Property<int>("IdItemProduto")
                        .HasColumnType("integer");

                    b.Property<int>("IdProduto")
                        .HasColumnType("integer");

                    b.Property<int?>("ItemProdutoModelIdItemProduto")
                        .HasColumnType("integer");

                    b.Property<int>("ProdutoIdProduto")
                        .HasColumnType("integer");

                    b.HasKey("IdItemProduto", "IdProduto");

                    b.HasIndex("ItemProdutoModelIdItemProduto");

                    b.HasIndex("ProdutoIdProduto");

                    b.ToTable("Vinculas");
                });

            modelBuilder.Entity("WebApplicationApi.Models.ClienteModel", b =>
                {
                    b.HasOne("WebApplicationApi.Models.ItemProdutoModel", "ItemProduto")
                        .WithMany("Clientes")
                        .HasForeignKey("ItemProdutoIdItemProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemProduto");
                });

            modelBuilder.Entity("WebApplicationApi.Models.VinculaModel", b =>
                {
                    b.HasOne("WebApplicationApi.Models.ItemProdutoModel", null)
                        .WithMany("Vinculas")
                        .HasForeignKey("ItemProdutoModelIdItemProduto");

                    b.HasOne("WebApplicationApi.Models.ProdutoModel", "Produto")
                        .WithMany("Vinculas")
                        .HasForeignKey("ProdutoIdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("WebApplicationApi.Models.ItemProdutoModel", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Vinculas");
                });

            modelBuilder.Entity("WebApplicationApi.Models.ProdutoModel", b =>
                {
                    b.Navigation("Vinculas");
                });
#pragma warning restore 612, 618
        }
    }
}
