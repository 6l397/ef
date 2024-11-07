namespace marketplace3.DataAccessLayer.Parameters
{
    public class SellerServiceCategoriesParameters : QueryStringParameters
    {
        public int? SellerId { get; set; }
        public int? ServiceCategoryId { get; set; }
    }
}
