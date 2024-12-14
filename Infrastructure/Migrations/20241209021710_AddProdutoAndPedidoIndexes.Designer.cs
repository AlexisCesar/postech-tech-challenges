﻿// <auto-generated />
using System;
using ControleDePedidos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleDePedidos.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241209021710_AddProdutoAndPedidoIndexes")]
    partial class AddProdutoAndPedidoIndexes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence<int>("Seq_CodAcompanhamento")
                .StartsAt(10L);

            modelBuilder.Entity("ControleDePedidos.Core.Entidades.AcompanhamentoAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<short>("CodigoAcompanhamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("nextval('\"Seq_CodAcompanhamento\"')");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Status")
                        .HasDatabaseName("IX_Status");

                    b.ToTable("Acompanhamento");
                });

            modelBuilder.Entity("ControleDePedidos.Core.Entidades.ClienteAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ControleDePedidos.Core.Entidades.ItemPedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Customizacao")
                        .HasColumnType("text");

                    b.Property<Guid?>("PedidoAggregateId")
                        .HasColumnType("uuid");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.Property<short>("Quantidade")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("PedidoAggregateId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItemPedido");
                });

            modelBuilder.Entity("ControleDePedidos.Core.Entidades.PagamentoAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Pago")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("ControleDePedidos.Core.Entidades.PedidoAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AcompanhamentoId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("HorarioRecebimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PagamentoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AcompanhamentoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PagamentoId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("ControleDePedidos.Core.Entidades.ProdutoAggregate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Categoria")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Categoria")
                        .HasDatabaseName("IX_Categoria");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("ControleDePedidos.Core.Entidades.ClienteAggregate", b =>
                {
                    b.OwnsOne("ControleDePedidos.Core.Entities.ValueObjects.CPF", "CPF", b1 =>
                        {
                            b1.Property<Guid>("ClienteAggregateId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("CPF");

                            b1.HasKey("ClienteAggregateId");

                            b1.ToTable("Cliente");

                            b1.WithOwner()
                                .HasForeignKey("ClienteAggregateId");
                        });

                    b.OwnsOne("ControleDePedidos.Core.Entities.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ClienteAggregateId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Email");

                            b1.HasKey("ClienteAggregateId");

                            b1.ToTable("Cliente");

                            b1.WithOwner()
                                .HasForeignKey("ClienteAggregateId");
                        });

                    b.Navigation("CPF");

                    b.Navigation("Email");
                });

            modelBuilder.Entity("ControleDePedidos.Core.Entidades.ItemPedido", b =>
                {
                    b.HasOne("ControleDePedidos.Core.Entidades.PedidoAggregate", null)
                        .WithMany("Itens")
                        .HasForeignKey("PedidoAggregateId");

                    b.HasOne("ControleDePedidos.Core.Entidades.ProdutoAggregate", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ControleDePedidos.Core.Entidades.PedidoAggregate", b =>
                {
                    b.HasOne("ControleDePedidos.Core.Entidades.AcompanhamentoAggregate", "Acompanhamento")
                        .WithMany()
                        .HasForeignKey("AcompanhamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleDePedidos.Core.Entidades.ClienteAggregate", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("ControleDePedidos.Core.Entidades.PagamentoAggregate", "Pagamento")
                        .WithMany()
                        .HasForeignKey("PagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acompanhamento");

                    b.Navigation("Cliente");

                    b.Navigation("Pagamento");
                });

            modelBuilder.Entity("ControleDePedidos.Core.Entidades.ProdutoAggregate", b =>
                {
                    b.OwnsOne("ControleDePedidos.Core.Entities.ValueObjects.Preco", "Preco", b1 =>
                        {
                            b1.Property<int>("ProdutoAggregateId")
                                .HasColumnType("integer");

                            b1.Property<double>("Value")
                                .HasColumnType("double precision")
                                .HasColumnName("Preco");

                            b1.HasKey("ProdutoAggregateId");

                            b1.ToTable("Produto");

                            b1.WithOwner()
                                .HasForeignKey("ProdutoAggregateId");
                        });

                    b.Navigation("Preco")
                        .IsRequired();
                });

            modelBuilder.Entity("ControleDePedidos.Core.Entidades.PedidoAggregate", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
