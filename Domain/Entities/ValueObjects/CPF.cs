using System.Text.RegularExpressions;

namespace ControleDePedidos.Core.Entities.ValueObjects
{
    public class CPF : ValueObject
    {
        public string Value { get; private set; }
        public CPF (string cpf) 
        { 
            SetCpf(cpf);
        }

        private CPF()
        {
            
        }

        private void SetCpf(string cpf)
        {
            string cpfPattern = @"^\d{3}\.\d{3}\.\d{3}\-\d{2}$";
            bool isValid = Regex.IsMatch(cpf, cpfPattern);

            if (isValid)
            {
                Value = cpf;
            }
            else
            {
                throw new ArgumentException("CPF inválido.");
            }

        }

        public override string? ToString()
        {
            return Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
