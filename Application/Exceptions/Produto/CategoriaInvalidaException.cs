namespace ControleDePedidos.Application.Exceptions.Produto
{
    public class CategoriaInvalidaException : Exception
    {
        public CategoriaInvalidaException()
        {
        }

        public CategoriaInvalidaException(string message)
            : base(message)
        {
        }

        public CategoriaInvalidaException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
