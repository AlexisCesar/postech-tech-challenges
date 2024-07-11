﻿// <auto-generated />
using System;
using ControleDePedidos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleDePedidos.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ControleDePedidos.Dominio.Entidades.AcompanhamentoAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("CodigoAcompanhamento")
                        .HasColumnType("smallint");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("Acompanhamento");
                });

            modelBuilder.Entity("ControleDePedidos.Dominio.Entidades.ClienteAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ControleDePedidos.Dominio.Entidades.ItemPedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Customizacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PedidoAggregateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("Quantidade")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("PedidoAggregateId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItemPedido");
                });

            modelBuilder.Entity("ControleDePedidos.Dominio.Entidades.PagamentoAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("ControleDePedidos.Dominio.Entidades.PedidoAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("ControleDePedidos.Dominio.Entidades.ProdutoAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("ControleDePedidos.Dominio.Entidades.AcompanhamentoAggregate", b =>
                {
                    b.HasOne("ControleDePedidos.Dominio.Entidades.PedidoAggregate", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("ControleDePedidos.Dominio.Entidades.ClienteAggregate", b =>
                {
                    b.OwnsOne("ControleDePedidos.Dominio.Entities.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ClienteAggregateId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Email");

                            b1.HasKey("ClienteAggregateId");

                            b1.ToTable("Cliente");

                            b1.WithOwner()
                                .HasForeignKey("ClienteAggregateId");
                        });

                    b.Navigation("Email");
                });

            modelBuilder.Entity("ControleDePedidos.Dominio.Entidades.ItemPedido", b =>
                {
                    b.HasOne("ControleDePedidos.Dominio.Entidades.PedidoAggregate", null)
                        .WithMany("Itens")
                        .HasForeignKey("PedidoAggregateId");

                    b.HasOne("ControleDePedidos.Dominio.Entidades.ProdutoAggregate", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ControleDePedidos.Dominio.Entidades.PagamentoAggregate", b =>
                {
                    b.HasOne("ControleDePedidos.Dominio.Entidades.PedidoAggregate", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("ControleDePedidos.Dominio.Entidades.PedidoAggregate", b =>
                {
                    b.HasOne("ControleDePedidos.Dominio.Entidades.ClienteAggregate", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ControleDePedidos.Dominio.Entidades.PedidoAggregate", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
