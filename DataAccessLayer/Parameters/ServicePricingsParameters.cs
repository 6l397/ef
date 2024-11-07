namespace marketplace3.DataAccessLayer.Parameters
{
    public class ServicePricingsParameters : QueryStringParameters
    {
        public int? SellerId { get; set; }
        public string ServiceName { get; set; }
    }
}
