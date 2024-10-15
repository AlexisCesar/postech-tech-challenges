using ControleDePedidos.Core.Entidades;

namespace ControleDePedidos.Application.Gateways
{
    public interface IClientePersistenceGateway
    {
        Task<bool> SalvarClienteAsync(ClienteAggregate clienteAggregate);
        Task<ClienteAggregate?> GetClienteByCPF(string cpf);
    }
}