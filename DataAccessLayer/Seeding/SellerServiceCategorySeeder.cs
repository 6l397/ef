using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using marketplace3.DataAccessLayer.Entities;
using marketplace3.DataAccessLayer.Interfaces;

namespace marketplace3.DataAccessLayer.Seeding
{
    public class SellerServiceCategorySeeder : ISeeder<SellerServiceCategory>
    {
        private static readonly List<SellerServiceCategory> sellerServiceCategories = new()
        {
            new SellerServiceCategory
            {
                SellerId = 1, // Вкажіть правильний ідентифікатор продавця
                ServiceCategoryId = 1 // Вкажіть правильний ідентифікатор категорії
            },
            new SellerServiceCategory
            {
                SellerId = 1,
                ServiceCategoryId = 2
            },
            new SellerServiceCategory
            {
                SellerId = 2, // Вкажіть правильний ідентифікатор продавця
                ServiceCategoryId = 3
            },
            new SellerServiceCategory
            {
                SellerId = 3,
                ServiceCategoryId = 4
            },
            new SellerServiceCategory
            {
                SellerId = 4,
                ServiceCategoryId = 5
            }
        };

        public void Seed(EntityTypeBuilder<SellerServiceCategory> builder)
        {
            foreach (var sellerServiceCategory in sellerServiceCategories)
            {
                builder.HasData(sellerServiceCategory);
            }
        }
    }
}
