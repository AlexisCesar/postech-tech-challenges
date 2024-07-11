namespace ControleDePedidos.Application.Exceptions
{
    public class CadastrarClienteException : Exception
    {
        public CadastrarClienteException()
        {
        }

        public CadastrarClienteException(string message)
            : base(message)
        {
        }

        public CadastrarClienteException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
