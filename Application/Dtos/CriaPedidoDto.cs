using System.ComponentModel.DataAnnotations;

namespace ControleDePedidos.Application.Dtos
{
    public class CriaPedidoDto
    {
        [RegularExpression(
            "^([0-9]){3}\\.([0-9]){3}\\.([0-9]){3}-([0-9]){2}$",
            ErrorMessage = "CPF Inválido. Utilize este padrão: 000.000.000-00"
        )]
        public string? CpfCliente { get; set; }

        [Required]
        public List<ItemPedidoDto> Itens { get; set; }
    }
}
