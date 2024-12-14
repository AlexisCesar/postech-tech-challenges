using ControleDePedidos.Application;
using ControleDePedidos.Application.Gateways;
using ControleDePedidos.Core.Entidades;
using ControleDePedidos.Core.Entities.Enums;
using Moq;

namespace ControleDePedidos.UseCases.Tests
{
    public class Tests
    {
        private ProdutoUseCases _produtoUseCases;
        private Mock<IProdutoPersistenceGateway> _produtoPersistenceGatewayMock;

        [SetUp]
        public void Setup()
        {
            ConfigureMocks();

            _produtoUseCases = new ProdutoUseCases(_produtoPersistenceGatewayMock.Object);
        }

        private void ConfigureMocks()
        {
            _produtoPersistenceGatewayMock = new Mock<IProdutoPersistenceGateway>();
        }

        [Test]
        public void CanCreate()
        {
            Assert.That(_produtoUseCases, Is.Not.Null);
        }
    }
}