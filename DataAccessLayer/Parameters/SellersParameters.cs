namespace marketplace3.DataAccessLayer.Parameters
{
    public class SellersParameters : QueryStringParameters
    {
        public int? LocationId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}
