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
    [Migration("20241109221715_UpdateProdutoPedidoRelationship")]
    partial class UpdateProdutoPedidoRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PedidoModelProdutoModel", b =>
                {
                    b.Property<int>("PedidosIdPedido")
                        .HasColumnType("integer");

                    b.Property<int>("ProdutosIdProduto")
                        .HasColumnType("integer");

                    b.HasKey("PedidosIdPedido", "ProdutosIdProduto");

                    b.HasIndex("ProdutosIdProduto");

                    b.ToTable("PedidoModelProdutoModel");
                });

            modelBuilder.Entity("WebApplicationApi.Models.ClienteModel", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdCliente"));

                    b.Property<DateTime>("DataNascimentoCliente")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EmailCliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumeroCliente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("WebApplicationApi.Models.PedidoModel", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdPedido"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("IdPedido");

                    b.HasIndex("ClienteId");

                    b.HasIndex("StatusId");

                    b.ToTable("Pedidos");
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

            modelBuilder.Entity("WebApplicationApi.Models.StatusModel", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdStatus"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomeStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdStatus");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("PedidoModelProdutoModel", b =>
                {
                    b.HasOne("WebApplicationApi.Models.PedidoModel", null)
                        .WithMany()
                        .HasForeignKey("PedidosIdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationApi.Models.ProdutoModel", null)
                        .WithMany()
                        .HasForeignKey("ProdutosIdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplicationApi.Models.PedidoModel", b =>
                {
                    b.HasOne("WebApplicationApi.Models.ClienteModel", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationApi.Models.StatusModel", "Status")
                        .WithMany("Pedidos")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("WebApplicationApi.Models.ClienteModel", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("WebApplicationApi.Models.StatusModel", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
