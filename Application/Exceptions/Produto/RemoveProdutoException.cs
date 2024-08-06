namespace ControleDePedidos.Application.Exceptions.Produto
{
    public class RemoveProdutoException : Exception
    {
        public RemoveProdutoException()
        {
        }

        public RemoveProdutoException(string message)
            : base(message)
        {
        }

        public RemoveProdutoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
