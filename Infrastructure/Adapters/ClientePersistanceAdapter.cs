using ControleDePedidos.Application.Ports;
using ControleDePedidos.Dominio.Entidades;
using ControleDePedidos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleDePedidos.Infrastructure.Adapters
{
    public class ClientePersistanceAdapter : IClientePersistancePort
    {
        private ApplicationContext Context;

        public ClientePersistanceAdapter(ApplicationContext context)
        {
            Context = context;    
        }

        public async Task<ClienteAggregate?> GetClienteByCPF(string cpf)
        {
            return await Context.Cliente.FirstOrDefaultAsync(c => c.CPF == cpf);
        }

        public async Task<bool> SalvarClienteAsync(ClienteAggregate clienteAggregate)
        {
            await Context.Cliente.AddAsync(clienteAggregate);

            var result = await Context.SaveChangesAsync();

            return result > 0;
        }
    }
}
