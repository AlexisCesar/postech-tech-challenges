namespace ControleDePedidos.Application.Exceptions.Produto
{
    public class ProdutoNaoCadastradoException : Exception
    {
        public ProdutoNaoCadastradoException()
        {
        }

        public ProdutoNaoCadastradoException(string message)
            : base(message)
        {
        }

        public ProdutoNaoCadastradoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
