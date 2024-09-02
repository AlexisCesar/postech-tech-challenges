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
        private Dictionary<string, int> PrioridadeStatus = Enum.GetValues(typeof(Status))
                                                                .Cast<Status>()
                                                                .Select((status, index) => new { status, index })
                                                                .ToDictionary(x => x.status.ToString(), x => x.index);

        public BuscarPedidoUseCase(IPedidoPersistencePort pedidoPersistencePort)
        {
            PedidoPersistencePort = pedidoPersistencePort;
        }

        public async Task<List<PedidoDto>> GetAllPedidosAsync()
        {
            var pedidos = await PedidoPersistencePort.GetAllPedidosNaoFinalizadosAsync();
            var pedidosDto = pedidos.Select(x => x.ToPedidoDto());

            return OrdernarPedidosPorStatusEHora(pedidosDto).ToList();
        }

        public async Task<List<PedidoDto>> GetAllPedidosByStatusAsync(Status status)
        {
            var acompanhamentos = await PedidoPersistencePort.GetAllPedidosByStatusAsync(status);
            var acompanhamentosDto = acompanhamentos.Select(x => x.ToPedidoDto());

            return acompanhamentosDto.OrderBy(x => x.HorarioRecebimento).ToList();
        }

        private IEnumerable<PedidoDto> OrdernarPedidosPorStatusEHora(IEnumerable<PedidoDto> pedidos)
        {
            return pedidos.OrderBy(p => PrioridadeStatus[p.StatusPedido!])
                            .ThenBy(p => p.HorarioRecebimento);
        }
    }
}
