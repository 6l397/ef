namespace marketplace3.DataAccessLayer.Entities
{
    public class ServicePricing
    {
        public int ServicePricingId { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
    }
}
