using ControleDePedidos.Core.Entidades;
using ControleDePedidos.Infrastructure.Models.MercadoPagoAPI;
using ControleDePedidos.UseCases.Gateways;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Text.Json;

namespace ControleDePedidos.Infrastructure.Gateways
{
    public class MercadoPagoPagamentoGateway : IApiPagamentoGateway
    {
        private const int PAYMENT_TIMEOUT_MINUTES = 15;

        public IConfiguration Configuration { get; }

        public MercadoPagoPagamentoGateway(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<string> GerarQrCodeParaPagamentoAsync(PedidoAggregate pedido)
        {
            var valorTotalPedido = pedido.CalcularValorPedido();

            var payload = JsonSerializer.Serialize(GerarPayloadMercadoPago(pedido, valorTotalPedido));

            MercadoPagoPedidoResponse? mpResponse = await EnviarRequisicao(payload);

            var qrCodeResponse = new MercadoPagoPagamentoViewModel()
            {
                QrCodeData = mpResponse?.qr_data
            };

            return qrCodeResponse.QrCodeData ?? "";
        }

        private async Task<MercadoPagoPedidoResponse?> EnviarRequisicao(string payload)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://api.mercadopago.com/instore/orders/qr/seller/collectors/{Configuration["USERID"]}/pos/{Configuration["POS_ID"]}/qrs");

            var token = Configuration["ACCESS_KEY"];
            request.Headers.Add("Authorization", $"Bearer {token}");

            request.Content = new StringContent(payload);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<MercadoPagoPedidoResponse>(await response.Content.ReadAsStringAsync());
        }

        private MercadoPagoPayload GerarPayloadMercadoPago(PedidoAggregate pedido, double valorTotalPedido)
        {
            return new MercadoPagoPayload()
            {
                external_reference = pedido.Id.ToString(),
                title = "Pedido " + pedido.Id,
                description = "Pedido na lanchonete.",
                total_amount = valorTotalPedido,
                expiration_date = DateTime.UtcNow.AddMinutes(PAYMENT_TIMEOUT_MINUTES).ToString("yyyy-MM-ddTHH:mm:ss.fffK", CultureInfo.InvariantCulture),
                items = new List<MercadoPagoItem>()
                {
                    new MercadoPagoItem()
                    {
                        category = "Pedido",
                            title = "Pedido " + pedido.Id.ToString(),
                            unit_price = valorTotalPedido,
                            quantity = 1,
                            total_amount = valorTotalPedido,
                            sponsor = new MercadoPagoSponsor()
                            {
                                id = long.Parse(Configuration["USERID"] ?? "0")
                            }
                    }
                },
                notification_url = $"{Configuration["NOTIFICATION_URL"]}/api/v1/Pedido/{pedido.Id}/confirmarPagamento"
            };
        }
    }
}
