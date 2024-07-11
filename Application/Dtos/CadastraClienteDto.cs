using System.ComponentModel.DataAnnotations;

namespace ControleDePedidos.Application.Dtos
{
    public class CadastraClienteDto
    {
        [Required]
        [RegularExpression(
            "^([0-9]){3}\\.([0-9]){3}\\.([0-9]){3}-([0-9]){2}$", 
            ErrorMessage = "CPF Inválido. Utilize este padrão: 000.000.000-00"
        )]
        public string? CPF { get; set; }

        [Required]
        [StringLength(
            maximumLength: 60, 
            MinimumLength = 1, 
            ErrorMessage = "O nome deve ter entre 1 e 100 caracteres."
        )]
        public string? Nome { get; set; }

        [Required]
        [RegularExpression(
            "^[A-z0-9.]+@[A-z0-9]+\\.[a-z]+(\\.[a-z]+)?$",
            ErrorMessage = "Formato de email inválido."
        )]
        public string? EnderecoEmail { get; set; }
    }
}
