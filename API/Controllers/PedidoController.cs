using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Application.Exceptions.Acompanhamento;
using ControleDePedidos.Application.Exceptions.Pagamento;
using ControleDePedidos.Application.Exceptions.Pedido;
using ControleDePedidos.Application.Exceptions.Produto;
using ControleDePedidos.Core.Entities.Enums;
using ControleDePedidos.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDePedidos.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IRealizarPedidoUseCase RealizarPedidoUseCase;
        private readonly IPagamentoUseCases PagamentoUseCases;
        private readonly IAcompanhamentoUseCases AcompanhamentoUseCases;
        private readonly IBuscarPedidoUseCase BuscarPedidoUseCase;

        public PedidoController(IRealizarPedidoUseCase realizarPedidoUseCase, 
                                IPagamentoUseCases pagamentoUseCases, 
                                IAcompanhamentoUseCases acompanhamentoUseCases, 
                                IBuscarPedidoUseCase buscarPedidoUseCase)
        {
            RealizarPedidoUseCase = realizarPedidoUseCase;
            PagamentoUseCases = pagamentoUseCases;
            AcompanhamentoUseCases = acompanhamentoUseCases;
            BuscarPedidoUseCase = buscarPedidoUseCase;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RealizaPedido([FromBody] CriaPedidoDto pedidoDto)
        {
            if(pedidoDto == null) return BadRequest("Pedido nao pode ser nulo.");

            try
            {
                var pedidoRealizadoDto = await RealizarPedidoUseCase.RealizarPedido(pedidoDto);

                return Ok(pedidoRealizadoDto);
            }
            catch (ProdutoNaoCadastradoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar a requisição, tente novamente mais tarde.");
            }
        }

        [HttpPost("{idPedido}/confirmarPagamento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConfirmaPagamento([FromRoute] Guid idPedido)
        {
            if (idPedido == Guid.Empty) return BadRequest("O id do pagamento nao pode ser nulo.");

            try
            {
                await PagamentoUseCases.ConfirmarPagamentoAsync(idPedido);

                return Ok();
            }
            catch (PedidoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ConfirmarPagamentoException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (AcompanhamentoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar a requisição, tente novamente mais tarde.");
            }

        }

        [HttpPost("{idPedido}/declararPronto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizaStatusComoPronto([FromRoute] Guid idPedido)
        {
            if (idPedido == Guid.Empty) return BadRequest("O id do pagamento nao pode ser nulo.");

            try
            {
                await AcompanhamentoUseCases.AtualizaStatusComoProntoAsync(idPedido);

                return Ok();
            }
            catch (PedidoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AcompanhamentoNaoEncontradoException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (OperacaoInvalidaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AtualizarStatusException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar a requisição, tente novamente mais tarde.");
            }

        }

        [HttpPost("{idPedido}/finalizar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FinalizaPedido([FromRoute] Guid idPedido)
        {
            if (idPedido == Guid.Empty) return BadRequest("O id do pagamento nao pode ser nulo.");

            try
            {
                await AcompanhamentoUseCases.FinalizaPedidoAsync(idPedido);

                return Ok();
            }
            catch (PedidoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AcompanhamentoNaoEncontradoException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (OperacaoInvalidaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AtualizarStatusException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar a requisição, tente novamente mais tarde.");
            }
        }

        [HttpGet("todos")]
        [ProducesResponseType(StatusCodes.Status200OK)]       
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllPedidos()
        {
            try
            {
                var pedidos = await BuscarPedidoUseCase.GetAllPedidosAsync();

                return Ok(pedidos);
            }         
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar a requisição, tente novamente mais tarde.");
            }
        }

        [HttpGet("recebidos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllPedidosWithStatusRecebido()
        {
            try
            {
                var pedidos = await BuscarPedidoUseCase.GetAllPedidosByStatusAsync(Status.Recebido);

                return Ok(pedidos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar a requisição, tente novamente mais tarde.");
            }
        }

        [HttpGet("emPreparacao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllPedidosWithStatusEmPreparacao()
        {
            try
            {
                var pedidos = await BuscarPedidoUseCase.GetAllPedidosByStatusAsync(Status.Preparacao);

                return Ok(pedidos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar a requisição, tente novamente mais tarde.");
            }
        }

        [HttpGet("prontos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllPedidosWithStatusPronto()
        {
            try
            {
                var pedidos = await BuscarPedidoUseCase.GetAllPedidosByStatusAsync(Status.Pronto);

                return Ok(pedidos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar a requisição, tente novamente mais tarde.");
            }
        }
    }
}
