using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace marketplace3.DataAccessLayer.Entities
{
    public class Seller
    {
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public ICollection<SellerServiceCategory> SellerServiceCategories { get; set; }
        public ICollection<ServicePricing> ServicePricings { get; set; }
    }
}
