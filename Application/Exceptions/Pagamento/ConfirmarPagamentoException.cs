namespace ControleDePedidos.Application.Exceptions.Pagamento
{
    [Serializable]
    public class ConfirmarPagamentoException : Exception
    {
        public ConfirmarPagamentoException()
        {
        }

        public ConfirmarPagamentoException(string? message) : base(message)
        {
        }

        public ConfirmarPagamentoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}