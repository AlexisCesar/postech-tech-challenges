using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Application.Exceptions;
using ControleDePedidos.Application.Extensions;
using ControleDePedidos.Application.Interfaces;
using ControleDePedidos.Application.Ports;
using ControleDePedidos.Dominio.Entidades;
using ControleDePedidos.Dominio.Entities.Enums;

namespace ControleDePedidos.Application
{
    public class PedidoApplication : IPedidoApplication
    {
        private readonly IPedidoPersistencePort PedidoPersistencePort;
        private readonly IClientePersistencePort ClientePersistencePort;
        private readonly IProdutoPersistencePort ProdutoPersistencePort;

        public PedidoApplication(IPedidoPersistencePort pedidoPersistencePort,
                                    IClientePersistencePort clientePersistencePort,
                                    IProdutoPersistencePort produtoPersistencePort)
        {
            PedidoPersistencePort = pedidoPersistencePort;
            ClientePersistencePort = clientePersistencePort;
            ProdutoPersistencePort = produtoPersistencePort;
        }

        public async Task<short> RealizarPedido(PedidoDto pedidoDto)
        {
            var cliente = await ClientePersistencePort.GetClienteByCPF(pedidoDto.CpfCliente ?? "");

            var produtos = await ProdutoPersistencePort.GetProdutosByIdsAsync(pedidoDto.Itens.Select(i => i.IdProduto));

            if(produtos.Count == 0 || produtos.Count != pedidoDto.Itens.Count)
            {
                throw new ProdutoNaoCadastradoException("Um ou mais produtos do pedido nao foram encontrados. Verifique o pedido.");
            }

            var pedido = pedidoDto.ToPedidoAggregate(cliente, produtos);

            var acompanhamento = new AcompanhamentoAggregate()
            {
                CodigoAcompanhamento = 999,
                Pedido = pedido,
                Status = Status.Recebido
            };

            var pedidoCadastrado = await PedidoPersistencePort.SavePedidoAndAcompanhamentoAsync(pedido, acompanhamento);

            if (!pedidoCadastrado) throw new RealizarPedidoException("Ocorreu um erro ao realizar o pedido.");

            return acompanhamento.CodigoAcompanhamento;
        }
    }
}
