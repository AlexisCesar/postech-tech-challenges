namespace ControleDePedidos.Infrastructure.Models.MercadoPagoAPI
{
    public class MercadoPagoItem
    {
        public string sku_number { get; set; }
        public string category { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double unit_price { get; set; }
        public int quantity { get; set; }
        public double total_amount { get; set; }
        public string unit_measure => "unit";
        public MercadoPagoSponsor sponsor { get; set; }
    }
}
