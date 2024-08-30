using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Core.Entidades;

namespace ControleDePedidos.Application.Interfaces
{
    public interface IClienteUseCases
    {
        Task CadastraClienteAsync(CadastraClienteDto clienteDto);
        Task<ClienteAggregate?> GetClienteByCPFAsync(string cpf);
    }
}
