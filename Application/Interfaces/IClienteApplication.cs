using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Core.Entidades;

namespace ControleDePedidos.Application.Interfaces
{
    public interface IClienteApplication
    {
        Task CadastraClienteAsync(CadastraClienteDto clienteDto);
        Task<ClienteAggregate?> GetClienteByCPFAsync(string cpf);
    }
}
