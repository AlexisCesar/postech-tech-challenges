namespace ControleDePedidos.Application.Exceptions
{
    [Serializable]
    public class OperacaoInvalidaException : Exception
    {
        public OperacaoInvalidaException()
        {
        }

        public OperacaoInvalidaException(string? message) : base(message)
        {
        }

        public OperacaoInvalidaException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}