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

        [Test]
        public void Test()
        {
            var sut = new UseCaseCopia(new Mock<IClientePersistenceGateway>().Object);

            var result = sut.RetornarBaseadoEmParametro(1);

            Assert.That(result, Is.EqualTo("a"));
        }

        [Test]
        public void Test2()
        {
            var sut = new UseCaseCopia(new Mock<IClientePersistenceGateway>().Object);

            var result = sut.RetornarBaseadoEmParametro(2);

            Assert.That(result, Is.EqualTo("b"));
        }
    }
}