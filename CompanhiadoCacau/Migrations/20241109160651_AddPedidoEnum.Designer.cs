﻿// <auto-generated />
using System;
using CompanhiadoCacau.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompanhiadoCacau.Migrations
{
    [DbContext(typeof(CiadoCacauContext))]
    [Migration("20241109160651_AddPedidoEnum")]
    partial class AddPedidoEnum
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CompanhiadoCacau.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("CompanhiadoCacau.Models.Endereco", b =>
                {
                    b.Property<int>("IdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEndereco"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComplementoValidado")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("IdEndereco");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("CompanhiadoCacau.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PedidoId"));

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("ResponsavelAtendimento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("PedidoId");

                    b.HasIndex("IdCliente");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("CompanhiadoCacau.Models.PedidoProduto", b =>
                {
                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("PedidoProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PedidoProdutoId"));

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("PedidoId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("PedidoProdutos");
                });

            modelBuilder.Entity("CompanhiadoCacau.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoId"));

                    b.Property<int>("Estoque")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProdutoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("CompanhiadoCacau.Models.Cliente", b =>
                {
                    b.HasOne("CompanhiadoCacau.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("CompanhiadoCacau.Models.Pedido", b =>
                {
                    b.HasOne("CompanhiadoCacau.Models.Cliente", "Cliente")
                        .WithMany("PedidosCliente")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("CompanhiadoCacau.Models.PedidoProduto", b =>
                {
                    b.HasOne("CompanhiadoCacau.Models.Pedido", "Pedido")
                        .WithMany("PedidoProdutos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CompanhiadoCacau.Models.Produto", "Produto")
                        .WithMany("PedidoProdutos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("CompanhiadoCacau.Models.Cliente", b =>
                {
                    b.Navigation("PedidosCliente");
                });

            modelBuilder.Entity("CompanhiadoCacau.Models.Pedido", b =>
                {
                    b.Navigation("PedidoProdutos");
                });

            modelBuilder.Entity("CompanhiadoCacau.Models.Produto", b =>
                {
                    b.Navigation("PedidoProdutos");
                });
#pragma warning restore 612, 618
        }
    }
}
