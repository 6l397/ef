namespace marketplace3.DataAccessLayer.Entities
{
    public class SellerServiceCategory
    {
        public int SellerId { get; set; }
        public Seller Seller { get; set; }

        public int ServiceCategoryId { get; set; }
        public ServiceCategory ServiceCategory { get; set; }
    }
}
