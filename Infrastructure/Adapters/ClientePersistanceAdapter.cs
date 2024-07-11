using ControleDePedidos.Application.Ports;
using ControleDePedidos.Dominio.Entidades;
using ControleDePedidos.Infrastructure.Data;

namespace ControleDePedidos.Infrastructure.Adapters
{
    public class ClientePersistanceAdapter : IClientePersistancePort
    {
        private ApplicationContext Context;

        public ClientePersistanceAdapter(ApplicationContext context)
        {
            Context = context;    
        }

        public async Task<bool> SalvarClienteAsync(ClienteAggregate clienteAggregate)
        {
            await Context.Cliente.AddAsync(clienteAggregate);

            var result = await Context.SaveChangesAsync();

            return result > 0;
        }
    }
}
