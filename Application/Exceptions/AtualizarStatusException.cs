namespace ControleDePedidos.Application.Exceptions
{
    [Serializable]
    public class AtualizarStatusException : Exception
    {
        public AtualizarStatusException()
        {
        }

        public AtualizarStatusException(string? message) : base(message)
        {
        }

        public AtualizarStatusException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}