using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Application.Extensions;
using ControleDePedidos.Application.Ports;
using ControleDePedidos.Core.Entities.Enums;
using ControleDePedidos.UseCases.Interfaces;

namespace ControleDePedidos.UseCases
{
    public class BuscarPedidoUseCase : IBuscarPedidoUseCase
    {
        private readonly IPedidoPersistencePort PedidoPersistencePort;

        public BuscarPedidoUseCase(IPedidoPersistencePort pedidoPersistencePort)
        {
            PedidoPersistencePort = pedidoPersistencePort;
        }

        public async Task<List<PedidoDto>> GetAllPedidosAsync()
        {
            var pedidos = await PedidoPersistencePort.GetAllPedidosNaoFinalizadosAsync();
            var pedidosDto = pedidos.Select(x => x.ToPedidoDto()).ToList();

            return pedidosDto;
        }

        public async Task<List<PedidoDto>> GetAllPedidosByStatusAsync(Status status)
        {
            var acompanhamentos = await PedidoPersistencePort.GetAllPedidosByStatusAsync(status);
            var acompanhamentosDto = acompanhamentos.Select(x => x.ToPedidoDto()).ToList();

            return acompanhamentosDto;
        }
    }
}
