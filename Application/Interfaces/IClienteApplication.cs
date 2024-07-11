using ControleDePedidos.Application.Dtos;

namespace ControleDePedidos.Application.Interfaces
{
    public interface IClienteApplication
    {
        Task CadastraClienteAsync(CadastraClienteDto clienteDto);
    }
}
