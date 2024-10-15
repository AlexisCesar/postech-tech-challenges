using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Core.Entities.ValueObjects;
using ControleDePedidos.Core.Entidades;

namespace ControleDePedidos.Application.Extensions
{
    static internal class CadastraClienteDtoExtensions
    {
        static internal ClienteAggregate ToClienteAggregate(this CadastraClienteDto clienteDto)
        {
            if (clienteDto == null)
            {
                return new ClienteAggregate();
            }

            return new ClienteAggregate()
            {
                CPF = new CPF(clienteDto.CPF),
                Email = new Email(clienteDto.EnderecoEmail ?? ""),
                Nome = clienteDto.Nome
            };
        }
    }
}
