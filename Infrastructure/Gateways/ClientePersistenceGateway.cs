using ControleDePedidos.Application.Gateways;
using ControleDePedidos.Core.Entidades;
using ControleDePedidos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleDePedidos.Infrastructure.Gateways
{
    internal class ClientePersistenceGateway : IClientePersistenceGateway
    {
        private ApplicationContext Context;

        public ClientePersistenceGateway(ApplicationContext context)
        {
            Context = context;    
        }

        public async Task<ClienteAggregate?> GetClienteByCPF(string cpf)
        {
            return await Context.Cliente.Include(x => x.CPF).FirstOrDefaultAsync(c => c.CPF != null && c.CPF.Value == cpf);
        }

        public async Task<bool> SalvarClienteAsync(ClienteAggregate clienteAggregate)
        {
            await Context.Cliente.AddAsync(clienteAggregate);

            var result = await Context.SaveChangesAsync();

            return result > 0;
        }
    }
}
