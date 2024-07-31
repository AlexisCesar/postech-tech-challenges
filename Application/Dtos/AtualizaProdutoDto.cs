using ControleDePedidos.Dominio.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleDePedidos.Application.Dtos
{
    public class AtualizaProdutoDto
    {
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(
            maximumLength: 20,
            MinimumLength = 1,
            ErrorMessage = "O nome deve ter entre 1 e 20 caracteres."
        )]
        public string Nome { get; set; }

        [Required]
        [Range(0.01, 100.00, ErrorMessage = "O preço deve estar entre 0.01 e 100.00.")]
        public double Preco { get; set; }

        [Required]
        [EnumDataType(typeof(Categoria))]
        public Categoria Categoria { get; set; }
    }
}
