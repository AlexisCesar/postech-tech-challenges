using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Application.Exceptions;
using ControleDePedidos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDePedidos.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PedidoController : ControllerBase
    {

        private readonly IPedidoApplication PedidoApplication;

        public PedidoController(IPedidoApplication pedidoApplication)
        {
            PedidoApplication = pedidoApplication;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RealizaPedido([FromBody] PedidoDto pedidoDto)
        {
            if(pedidoDto == null) return BadRequest("Pedido nao pode ser nulo.");

            try
            {
                var pedidoRealizadoDto = await PedidoApplication.RealizarPedido(pedidoDto);

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

        [HttpPost("pagamento/confirmar/{idPagamento}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConfirmaPagamento([FromRoute] Guid idPagamento)
        {
            if (idPagamento == Guid.Empty) return BadRequest("O id do pagamento nao pode ser nulo.");

            try
            {
                await PedidoApplication.ConfirmarPagamentoAsync(idPagamento);

                return Ok();
            }
            catch (PagamentoNaoEncontradoException ex)
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

        [HttpPost("{idPedido}/status/pronto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizaStatusComoPronto([FromRoute] Guid idPedido)
        {
            if (idPedido == Guid.Empty) return BadRequest("O id do pagamento nao pode ser nulo.");

            try
            {
                await PedidoApplication.AtualizaStatusComoProntoAsync(idPedido);

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
    }
}
