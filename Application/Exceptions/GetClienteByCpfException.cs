namespace ControleDePedidos.Application.Exceptions
{
    public class GetClienteByCpfException : Exception
    {
        public GetClienteByCpfException(string message) : base (message) { }

        public GetClienteByCpfException(string message, Exception inner)
          : base(message, inner)
        {
        }
    }
}
