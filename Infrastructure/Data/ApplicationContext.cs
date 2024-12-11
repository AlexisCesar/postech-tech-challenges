using ControleDePedidos.Core.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ControleDePedidos.Infrastructure.Data
{
    internal class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host={Environment.GetEnvironmentVariable("DB_HOST")}; Database={Environment.GetEnvironmentVariable("DB_NAME")}; Username={Environment.GetEnvironmentVariable("DB_USER")}; Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<ClienteAggregate> Cliente { get; set; }
        public DbSet<AcompanhamentoAggregate> Acompanhamento { get; set; }
        public DbSet<PagamentoAggregate>  Pagamento { get; set; }
        public DbSet<ProdutoAggregate> Produto { get; set; }
        public DbSet<PedidoAggregate> Pedido { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClienteAggregate>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.OwnsOne(e => e.Email, email =>
                {
                    email.Property(e => e.Endereco).HasColumnName("Email");
                });

                entity.OwnsOne(e => e.CPF, cpf =>
                {
                    cpf.Property(e => e.Value).HasColumnName("CPF");
                });
            });

            modelBuilder.HasSequence<int>("Seq_CodAcompanhamento")
                .StartsAt(10)
                .IncrementsBy(1);

            modelBuilder.Entity<AcompanhamentoAggregate>(Entity => {
                Entity.HasKey(e => e.Id);
                Entity.Property(e => e.CodigoAcompanhamento)
                    .HasDefaultValueSql("nextval('\"Seq_CodAcompanhamento\"')");
                Entity.HasIndex(e => e.Status)
                    .HasDatabaseName("IX_Status");
            });

            modelBuilder.Entity<ProdutoAggregate>(Entity =>
            {
                Entity.HasKey(e => e.Id);

                Entity.OwnsOne(e => e.Preco, preco =>
                {
                    preco.Property(e => e.Value).HasColumnName("Preco");
                });
                Entity.HasIndex(e => e.Categoria)
                    .HasDatabaseName("IX_Categoria");
            });

            modelBuilder.Entity<ItemPedido>(Entity => Entity.HasKey(e => e.Id));
            modelBuilder.Entity<PagamentoAggregate>(Entity => Entity.HasKey(e => e.Id));
            modelBuilder.Entity<PedidoAggregate>(Entity => Entity.HasKey(e => e.Id));
        }
    }
}
