using System.Text.RegularExpressions;

namespace ControleDePedidos.Core.Entities.ValueObjects
{
    public class Email : ValueObject
    {
        public string Endereco { get; }
        public Email(string endereco) 
        {
            var enderecoPattern = "^[A-z0-9.]+@[A-z0-9]+\\.[a-z]+(\\.[a-z]+)?$";
            bool isValid = Regex.IsMatch(endereco, enderecoPattern);

            if (isValid)
            {
                Endereco = endereco;
            }
            else
            {
                throw new ArgumentException("Email inválido.");
            }
        }

        private Email()
        {
            
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Endereco;
        }
    }
}
