using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Application.Exceptions;
using ControleDePedidos.Application.Extensions;
using ControleDePedidos.Application.Interfaces;
using ControleDePedidos.Application.Ports;
using ControleDePedidos.Dominio.Entidades;
using System.Text.RegularExpressions;

namespace ControleDePedidos.Application
{
    public partial class ClienteApplication : IClienteApplication
    {
        private readonly IClientePersistencePort ClientePersistancePort;

        public ClienteApplication(IClientePersistencePort clientePersistancePort)
        {
            ClientePersistancePort = clientePersistancePort;
        }

        public async Task CadastraClienteAsync(CadastraClienteDto clienteDto)
        {
            if (clienteDto == null) throw new CadastrarClienteException("Ocorreu um erro ao cadastrar o cliente.");

            if (await VerificarClienteJaCadastrado(clienteDto.CPF!)) throw new ClienteJaCadastradoException("Cliente ja possui cadastro.");

            var clienteAggregate = clienteDto.ToClienteAggregate();
            
            var clienteCadastrado = await ClientePersistancePort.SalvarClienteAsync(clienteAggregate);

            if(!clienteCadastrado) throw new CadastrarClienteException("Ocorreu um erro ao cadastrar o cliente.");
        }

        public async Task<ClienteAggregate?> GetClienteByCPFAsync(string cpf)
        {
            if (string.IsNullOrEmpty(cpf) || !CpfRegex().IsMatch(cpf))
                throw new GetClienteByCpfException("CPF Inválido. Utilize este padrão: 000.000.000-00");

            var cliente = await ClientePersistancePort.GetClienteByCPF(cpf);

            return cliente;

        }

        [GeneratedRegex("^([0-9]){3}\\.([0-9]){3}\\.([0-9]){3}-([0-9]){2}$")]
        private static partial Regex CpfRegex();

        private async Task<bool> VerificarClienteJaCadastrado(string cpf)
        {
            var cliente = await GetClienteByCPFAsync(cpf);

            return cliente != null;
        }
    }
}
