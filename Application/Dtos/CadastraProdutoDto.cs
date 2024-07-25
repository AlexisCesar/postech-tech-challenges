using ControleDePedidos.Dominio.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ControleDePedidos.Application.Dtos
{
    public class CadastraProdutoDto
    {
        [Required]
        [StringLength(
            maximumLength: 20,
            MinimumLength = 1,
            ErrorMessage = "O nome deve ter entre 1 e 20 caracteres."
        )]
        public string Nome { get; set; }

        [Required]
        public double Preco { get; set; }

        [Required]
        [EnumDataType(typeof(Categoria))]
        public Categoria Categoria { get; set; }
    }
}
