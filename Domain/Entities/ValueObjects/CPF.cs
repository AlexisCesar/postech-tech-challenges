using System.Text.RegularExpressions;

namespace ControleDePedidos.Core.Entities.ValueObjects
{
    public class CPF : ValueObject
    {
        private string Cpf { get; set; }
        public CPF (string cpf) 
        { 
            SetCpf(cpf);
        }

        private void SetCpf(string cpf)
        {
            string cpfPattern = @"^\d{3}\.\d{3}\.\d{3}\-\d{2}$";
            bool isValid = Regex.IsMatch(cpf, cpfPattern);

            if (isValid)
            {
                Cpf = cpf;
            }
            else
            {
                throw new ArgumentException("CPF inválido.");
            }

        }

        public override string? ToString()
        {
            return Cpf;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Cpf;
        }
    }
}
