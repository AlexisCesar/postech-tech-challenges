﻿using ControleDePedidos.Application.Dtos;
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CadastraProduto([FromBody] CadastraProdutoDto produto)
        {
            try
            {
                await ProdutoApplication.CadastraProdutoAsync(produto);

                return Ok(produto);
            }
            catch (CadastrarProdutoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProdutoJaCadastradoException ex)
            {
                return Conflict(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar a requisição, tente novamente mais tarde.");
            }           
        }

        [HttpGet]
        [Route("todos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscaProdutos()
        {
            try
            {
                var produtos = await ProdutoApplication.BuscaProdutosAsync();

                return produtos.Any() ? Ok(produtos) : NotFound();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar a requisição, tente novamente mais tarde.");
            }           
        }
    }
}
