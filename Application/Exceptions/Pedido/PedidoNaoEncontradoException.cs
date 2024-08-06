namespace ControleDePedidos.Application.Exceptions.Pedido
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