﻿using ControleDePedidos.Dominio.Entidades;
using ControleDePedidos.Dominio.Entities.Enums;

namespace ControleDePedidos.Application.Ports
{
    public interface IPedidoPersistencePort
    {
        Task<bool> SaveAcompanhamentoAsync(AcompanhamentoAggregate acompanhamento);
        Task<bool> SavePedidoAsync(PedidoAggregate pedido);
        Task <PedidoAggregate?> GetPedidoById (Guid idPedido);
        Task<List<PedidoAggregate>> GetAllPedidosNaoFinalizadosAsync();
        Task<List<PedidoAggregate>> GetAllPedidosByStatusAsync(Status status);
        Task<bool> SavePagamentoAsync(PagamentoAggregate pagamento);  
    }
}