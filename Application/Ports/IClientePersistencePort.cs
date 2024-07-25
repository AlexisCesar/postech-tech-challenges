using ControleDePedidos.Dominio.Entidades;

namespace ControleDePedidos.Application.Ports
{
    public interface IClientePersistencePort
    {
        Task<bool> SalvarClienteAsync(ClienteAggregate clienteAggregate);
        Task<ClienteAggregate?> GetClienteByCPF(string cpf);
    }
}