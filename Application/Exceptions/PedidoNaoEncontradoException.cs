namespace ControleDePedidos.Application.Exceptions
{
    [Serializable]
    public class PedidoNaoEncontradoException : Exception
    {
        public PedidoNaoEncontradoException()
        {
        }

        public PedidoNaoEncontradoException(string? message) : base(message)
        {
        }

        public PedidoNaoEncontradoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}