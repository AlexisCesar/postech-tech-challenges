namespace ControleDePedidos.Dominio.ValueObjects
{
    public class Email : ValueObject
    {
        public Email() { }
        public string Endereco { get; set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Endereco;
        }
    }
}
