using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Application.Exceptions;
using ControleDePedidos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDePedidos.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClienteController : ControllerBase
    {
        private IClienteApplication ClientApplication;

        public ClienteController(IClienteApplication clientApplication)
        {
            ClientApplication = clientApplication;
        }

        [HttpPost]
        [Route("cadastro")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CadastraClienteDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastraCliente([FromBody] CadastraClienteDto cadastraClienteDto)
        {
            try
            {
                await ClientApplication.CadastraClienteAsync(cadastraClienteDto);

                return Ok(cadastraClienteDto);
            }
            catch (CadastrarClienteException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult BuscaCliente([FromBody] string cpf)
        {
            return Ok(new ClienteDto() { Nome = "Bruna", Email = "bruna@gmail.com" });
        }
    }
}
