namespace ControleDePedidos.Application.Exceptions.Produto
{
    public class CadastrarProdutoException : Exception
    {
        public CadastrarProdutoException()
        {
        }

        public CadastrarProdutoException(string message)
            : base(message)
        {
        }

        public CadastrarProdutoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
