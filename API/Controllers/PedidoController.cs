using ControleDePedidos.Application.Dtos;
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
        public IActionResult RealizaPedido([FromBody] PedidoDto pedidoDto)
        {
            if(pedidoDto == null) return BadRequest("Pedido nao pode ser nulo.");

            return Ok();
        }
    }
}
