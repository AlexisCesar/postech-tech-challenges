using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Application.Exceptions;
using ControleDePedidos.Application.Extensions;
using ControleDePedidos.Application.Interfaces;
using ControleDePedidos.Application.Ports;
using ControleDePedidos.Dominio.Entidades;
using System.Text.RegularExpressions;

namespace ControleDePedidos.Application
{
    public class ClienteApplication : IClienteApplication
    {
        private readonly IClientePersistancePort ClientePersistancePort;

        public ClienteApplication(IClientePersistancePort clientePersistancePort)
        {
            ClientePersistancePort = clientePersistancePort;
        }

        public async Task CadastraClienteAsync(CadastraClienteDto clienteDto)
        {
            var clienteAggregate = clienteDto.ToClienteAggregate();
            
            var clienteCadastrado = await ClientePersistancePort.SalvarClienteAsync(clienteAggregate);

            if(!clienteCadastrado) throw new CadastrarClienteException("Ocorreu um erro ao cadastrar o cliente.");
        }
        public async Task<ClienteAggregate?> GetClienteByCPFAsync(string cpf)
        {
            if (!Regex.IsMatch(cpf, "^([0-9]){3}\\.([0-9]){3}\\.([0-9]){3}-([0-9]){2}$"))
                throw new GetClienteByCpfException("CPF Inválido. Utilize este padrão: 000.000.000-00");
                     
            var cliente = await ClientePersistancePort.GetClienteByCPF(cpf);

            return cliente;

        }
    }
}
