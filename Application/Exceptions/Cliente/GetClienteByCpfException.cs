namespace ControleDePedidos.Application.Exceptions.Cliente
{
    public class GetClienteByCpfException : Exception
    {
        public GetClienteByCpfException(string message) : base(message) { }

        public GetClienteByCpfException(string message, Exception inner)
          : base(message, inner)
        {
        }
    }
}
