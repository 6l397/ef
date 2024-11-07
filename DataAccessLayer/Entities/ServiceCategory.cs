    namespace marketplace3.DataAccessLayer.Entities
    {
        public class ServiceCategory
        {
            public int ServiceCategoryId { get; set; }
            public string CategoryName { get; set; }
            public ICollection<SellerServiceCategory> SellerServiceCategories { get; set; }
        }
    }
