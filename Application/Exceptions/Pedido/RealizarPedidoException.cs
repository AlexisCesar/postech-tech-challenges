namespace ControleDePedidos.Application.Exceptions.Pedido
{
    [Serializable]
    internal class RealizarPedidoException : Exception
    {
        public RealizarPedidoException()
        {
        }

        public RealizarPedidoException(string? message) : base(message)
        {
        }

        public RealizarPedidoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}