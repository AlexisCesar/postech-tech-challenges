using ControleDePedidos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ControleDePedidos.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=lanchonetedobairro_db,1433;Database=controleDePedidos;User=sa;Password=Posgraduation@109283;Encrypt=True;TrustServerCertificate=True;");
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
            });

            modelBuilder.Entity<AcompanhamentoAggregate>(Entity => Entity.HasKey(e => e.Id));
            modelBuilder.Entity<ItemPedido>(Entity => Entity.HasKey(e => e.Id));
            modelBuilder.Entity<PagamentoAggregate>(Entity => Entity.HasKey(e => e.Id));
            modelBuilder.Entity<ProdutoAggregate>(Entity => Entity.HasKey(e => e.Id));
            modelBuilder.Entity<PedidoAggregate>(Entity => Entity.HasKey(e => e.Id));
        }
    }
}
