namespace ControleDePedidos.Application.Exceptions
{
    [Serializable]
    public class PagamentoNaoEncontradoException : Exception
    {
        public PagamentoNaoEncontradoException()
        {
        }

        public PagamentoNaoEncontradoException(string? message) : base(message)
        {
        }

        public PagamentoNaoEncontradoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}