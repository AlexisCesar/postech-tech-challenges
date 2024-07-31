namespace ControleDePedidos.Application.Exceptions
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