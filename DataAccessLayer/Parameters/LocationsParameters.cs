namespace marketplace3.DataAccessLayer.Parameters
{
    public class LocationsParameters : QueryStringParameters
    {
        public string City { get; set; }
        public string StreetAddress { get; set; }
    }
}
