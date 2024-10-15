namespace ControleDePedidos.Infrastructure.Models.MercadoPagoAPI
{
    public class MercadoPagoPayload
    {

        public string external_reference { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double total_amount { get; set; }
        public string expiration_date { get; set; }
        public IEnumerable<MercadoPagoItem> items { get; set; } = new List<MercadoPagoItem>();
        public string notification_url { get; set; }
    }
}
