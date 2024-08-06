namespace ControleDePedidos.Application.Exceptions.Produto
{
    public class AtualizaProdutoException : Exception
    {
        public AtualizaProdutoException()
        {
        }

        public AtualizaProdutoException(string message)
            : base(message)
        {
        }

        public AtualizaProdutoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
