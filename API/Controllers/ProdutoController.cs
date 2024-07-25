using ControleDePedidos.Application;
using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Application.Exceptions;
using ControleDePedidos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDePedidos.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProdutoController : Controller
    {
        private IProdutoApplication ProdutoApplication;

        public ProdutoController(IProdutoApplication produtoApplication)
        {
            ProdutoApplication = produtoApplication;
        }
        [HttpPost]
        [Route("cadastro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastraProduto([FromBody] CadastraProdutoDto produto)
        {
            try
            {
                await ProdutoApplication.CadastraProdutoAsync(produto);

                return Ok(produto);
            }
            catch (CadastrarClienteException ex)
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
