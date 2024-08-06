namespace ControleDePedidos.Application.Exceptions.Cliente
{
    public class ClienteJaCadastradoException : Exception
    {
        public ClienteJaCadastradoException()
        {
        }

        public ClienteJaCadastradoException(string message)
            : base(message)
        {
        }

        public ClienteJaCadastradoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
