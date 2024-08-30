namespace ControleDePedidos.UseCases.Interfaces
{
    public interface IPagamentoUseCases
    {
        Task ConfirmarPagamentoAsync(Guid idPedido);
    }
}
