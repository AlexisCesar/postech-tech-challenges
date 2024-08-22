using ControleDePedidos.Core.Entidades;

namespace ControleDePedidos.Application.Ports
{
    public interface IClientePersistencePort
    {
        Task<bool> SalvarClienteAsync(ClienteAggregate clienteAggregate);
        Task<ClienteAggregate?> GetClienteByCPF(string cpf);
    }
}