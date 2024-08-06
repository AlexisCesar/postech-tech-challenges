namespace ControleDePedidos.Application.Exceptions.Acompanhamento
{
    [Serializable]
    public class AcompanhamentoNaoEncontradoException : Exception
    {
        public AcompanhamentoNaoEncontradoException()
        {
        }

        public AcompanhamentoNaoEncontradoException(string? message) : base(message)
        {
        }

        public AcompanhamentoNaoEncontradoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}