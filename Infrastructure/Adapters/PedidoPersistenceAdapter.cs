using ControleDePedidos.Application.Ports;
using ControleDePedidos.Dominio.Entidades;
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

        public async Task<AcompanhamentoAggregate?> GetAcompanhamentoByPedidoIdAsync(Guid idPedido)
        {
            var acompanhamento = await Context.Acompanhamento.Include(x => x.Pedido).FirstOrDefaultAsync(x => x.Pedido.Id == idPedido);

            return acompanhamento;
        }

        public async Task<PagamentoAggregate?> GetPagamentoByIdAsync(Guid idPagamento)
        {
            var pagamento = await Context.Pagamento.Include(x => x.Pedido).FirstOrDefaultAsync(x => x.Id == idPagamento);

            return pagamento;
        }

        public async Task<PedidoAggregate?> GetPedidoById(Guid idPedido)
        {
            var pedido = await Context.Pedido.FirstOrDefaultAsync(x => x.Id == idPedido);

            return pedido;
        }

        public async Task<bool> SaveAcompanhamentoAsync(AcompanhamentoAggregate acompanhamento)
        {
            Context.Acompanhamento.Update(acompanhamento);

            var result = await Context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> SavePedidoAndAcompanhamentoAsync(PedidoAggregate pedido, AcompanhamentoAggregate acompanhamento, PagamentoAggregate pagamento)
        {
            await Context.Pedido.AddAsync(pedido);
            await Context.Acompanhamento.AddAsync(acompanhamento);
            await Context.Pagamento.AddAsync(pagamento);

            var result = await Context.SaveChangesAsync();

            return result > 0;
        }
    }
}
