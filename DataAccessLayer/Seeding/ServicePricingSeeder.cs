using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using marketplace3.DataAccessLayer.Entities;
using marketplace3.DataAccessLayer.Interfaces;

namespace marketplace3.DataAccessLayer.Seeding
{
    public class ServicePricingSeeder : ISeeder<ServicePricing>
    {
        private static readonly List<ServicePricing> servicePricings = new()
    {
        new ServicePricing
        {
            ServicePricingId = 1,
            SellerId = 1,
            ServiceName = "Dog Grooming",
            Price = 50.00m
        },
        new ServicePricing
        {
            ServicePricingId = 2,
            SellerId = 1,
            ServiceName = "Dog Walking",
            Price = 25.00m
        },
        new ServicePricing
        {
            ServicePricingId = 3,  // Змініть ID на унікальний
            SellerId = 2,
            ServiceName = "Veterinary Check-up",
            Price = 100.00m
        },
        new ServicePricing
        {
            ServicePricingId = 4,  // Змініть ID на унікальний
            SellerId = 3,
            ServiceName = "Pet Sitting",
            Price = 30.00m
        }
    };

        public void Seed(EntityTypeBuilder<ServicePricing> builder)
        {
            builder.HasData(servicePricings);
        }
    }

}
