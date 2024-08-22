
namespace ControleDePedidos.Core.Entities.ValueObjects
{
    public class Preco : ValueObject
    {
        public double Valor { get; }

        public Preco(double valor) 
        {
            if(valor < 0)
            {
                throw new ArgumentOutOfRangeException("O preço não pode ser negativo.");
            }

            Valor = valor;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Valor;
        }
    }
}