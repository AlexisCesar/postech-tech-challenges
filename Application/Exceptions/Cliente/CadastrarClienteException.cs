namespace ControleDePedidos.Application.Exceptions.Cliente
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
