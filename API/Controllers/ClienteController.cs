using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Application.Exceptions.Cliente;
using ControleDePedidos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDePedidos.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteUseCases ClientApplication;

        public ClienteController(IClienteUseCases clientApplication)
        {
            ClientApplication = clientApplication;
        }

        [HttpPost]
        [Route("cadastro")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CadastraClienteDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
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
            catch (ClienteJaCadastradoException ex)
            {
                return Conflict(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar a requisição, tente novamente mais tarde.");
            }
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscaCliente([FromBody] string cpf)
        {
            try
            {
                var cliente = await ClientApplication.GetClienteByCPFAsync(cpf);
                return cliente == null ? NotFound("Cliente nao encontrado.") : Ok(cliente);
            }
            catch (GetClienteByCpfException ex)
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
