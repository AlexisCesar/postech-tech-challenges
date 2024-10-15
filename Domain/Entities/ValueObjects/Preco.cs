
namespace ControleDePedidos.Core.Entities.ValueObjects
{
    public class Preco : ValueObject
    {
        public double Value { get; }

        public Preco(double value) 
        {
            if(value < 0)
            {
                throw new ArgumentOutOfRangeException("O preço não pode ser negativo.");
            }

            Value = value;
        }

        private Preco()
        {
            
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}