using ControleDePedidos.Application.Ports;
using ControleDePedidos.Core.Entidades;
using ControleDePedidos.Core.Entities.Enums;
using ControleDePedidos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleDePedidos.Infrastructure.Adapters
{
    public class PedidoPersistenceAdapter : IPedidoPersistencePort
    {
        private ApplicationContext Context;

        public PedidoPersistenceAdapter(ApplicationContext context)
        {
            Context = context;
        }

        public async Task<List<PedidoAggregate>> GetAllPedidosByStatusAsync(Status status)
        {
            return await Context.Pedido
                       .Include(x => x.Cliente)
                       .Include(x => x.Acompanhamento)
                       .Include(x => x.Pagamento)
                       .Include(p => p.Itens)
                       .ThenInclude(p => p.Produto)
                       .Where(x => x.Acompanhamento.Status == status)
                       .ToListAsync();
        }

        public async Task<List<PedidoAggregate>> GetAllPedidosNaoFinalizadosAsync()
        {          
            return await Context.Pedido
                        .Include(x => x.Cliente)
                        .Include(x => x.Acompanhamento)
                        .Include(x => x.Pagamento)
                        .Include(p => p.Itens)
                        .ThenInclude(p => p.Produto)
                        .Where(x => x.Acompanhamento.Status != Status.Finalizado)
                        .ToListAsync();
        }

        public async Task<PedidoAggregate?> GetPedidoById(Guid idPedido)
        {
            var pedido = 
                await Context.Pedido
                        .Include(x => x.Cliente)
                        .Include(x => x.Acompanhamento)
                        .Include(x => x.Pagamento)
                        .Include(p => p.Itens)
                        .ThenInclude(p => p.Produto)
                        .FirstOrDefaultAsync(x => x.Id == idPedido);

            return pedido;
        }

        public async Task<bool> SaveAcompanhamentoAsync(AcompanhamentoAggregate acompanhamento)
        {
            Context.Acompanhamento.Update(acompanhamento);

            var result = await Context.SaveChangesAsync();

            return result > 0;
        }
        public async Task<bool> SavePagamentoAsync(PagamentoAggregate pagamento)
        {
            Context.Pagamento.Update(pagamento);

            var result = await Context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> SavePedidoAsync(PedidoAggregate pedido)
        {
            await Context.Pedido.AddAsync(pedido);

            var result = await Context.SaveChangesAsync();

            return result > 0;
        }
    }
}
 