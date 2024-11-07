using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using marketplace3.DataAccessLayer.Entities;
using marketplace3.DataAccessLayer.Interfaces;

namespace marketplace3.DataAccessLayer.Seeding
{
    public class ServiceCategorySeeder : ISeeder<ServiceCategory>
    {
        private static readonly List<ServiceCategory> serviceCategories = new()
        {
            new ServiceCategory
            {
                ServiceCategoryId = 1,
                CategoryName = "Cleaning"
            },
            new ServiceCategory
            {
                ServiceCategoryId = 2,
                CategoryName = "Grooming"
            },
            new ServiceCategory
            {
                ServiceCategoryId = 3,
                CategoryName = "Training"
            },
            new ServiceCategory
            {
                ServiceCategoryId = 4,
                CategoryName = "Pet Sitting"
            },
            new ServiceCategory
            {
                ServiceCategoryId = 5,
                CategoryName = "Walking"
            }
        };

        public void Seed(EntityTypeBuilder<ServiceCategory> builder)
        {
            foreach (var serviceCategory in serviceCategories)
            {
                builder.HasData(serviceCategory);
            }
        }
    }
}
