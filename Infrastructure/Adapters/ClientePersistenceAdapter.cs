using ControleDePedidos.Application.Ports;
using ControleDePedidos.Core.Entidades;
using ControleDePedidos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleDePedidos.Infrastructure.Adapters
{
    public class ClientePersistenceAdapter : IClientePersistencePort
    {
        private ApplicationContext Context;

        public ClientePersistenceAdapter(ApplicationContext context)
        {
            Context = context;    
        }

        public async Task<ClienteAggregate?> GetClienteByCPF(string cpf)
        {
            return await Context.Cliente.FirstOrDefaultAsync(c => c.CPF.ToString() == cpf);
        }

        public async Task<bool> SalvarClienteAsync(ClienteAggregate clienteAggregate)
        {
            await Context.Cliente.AddAsync(clienteAggregate);

            var result = await Context.SaveChangesAsync();

            return result > 0;
        }
    }
}
