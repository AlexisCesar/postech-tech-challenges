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
                var codigoAcompanhamento = await PedidoApplication.RealizarPedido(pedidoDto);

                return Ok(codigoAcompanhamento);
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
    }
}
