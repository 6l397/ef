namespace marketplace3.BusinessLogicLayer.DTO.Requests
{
    public class ServicePricingRequest
    {
        public int SellerId { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
    }
}
