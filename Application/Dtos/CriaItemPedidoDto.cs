using System.ComponentModel.DataAnnotations;

namespace ControleDePedidos.UseCases.Dtos
{
    public class CriaItemPedidoDto
    {
        [Required]
        public int IdProduto { get; set; }
        [Required]
        [Range(1, 200, ErrorMessage = "A quantidade deve ser maior do que 0 e menor ou igual a 200.")]
        public short Quantidade { get; set; }
        [StringLength(
            maximumLength: 200,
            MinimumLength = 0,
            ErrorMessage = "A nota de customizacao deve ter entre 0 a 200 caracteres."
        )]
        public string? Customizacao { get; set; }
    }
}
