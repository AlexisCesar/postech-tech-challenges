using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDePedidos.Application.Exceptions
{
    public class CadastrarProdutoException : Exception
    {
        public CadastrarProdutoException()
        {
        }

        public CadastrarProdutoException(string message)
            : base(message)
        {
        }

        public CadastrarProdutoException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
