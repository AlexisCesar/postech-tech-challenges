using ControleDePedidos.Application.Ports;
using ControleDePedidos.Dominio.Entidades;
using ControleDePedidos.Infrastructure.Data;

namespace ControleDePedidos.Infrastructure.Adapters
{
    public class PedidoPersistenceAdapter : IPedidoPersistencePort
    {
        private ApplicationContext Context;

        public PedidoPersistenceAdapter(ApplicationContext context)
        {
            Context = context;
        }

        public async Task<bool> SavePedidoAndAcompanhamentoAsync(PedidoAggregate pedido, AcompanhamentoAggregate acompanhamento)
        {
            await Context.Pedido.AddAsync(pedido);
            await Context.Acompanhamento.AddAsync(acompanhamento);

            var result = await Context.SaveChangesAsync();

            return result > 0;
        }
    }
}
