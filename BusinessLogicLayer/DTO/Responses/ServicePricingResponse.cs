namespace marketplace3.BusinessLogicLayer.DTO.Responses
{
    public class ServicePricingResponse
    {
        public int ServicePricingId { get; set; }
        public int SellerId { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
    }
}
