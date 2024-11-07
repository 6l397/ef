using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using marketplace3.DataAccessLayer.Interfaces;
using marketplace3.DataAccessLayer.Entities;

namespace marketplace3.DataAccessLayer.Seeding
{
    public class SellerSeeder : ISeeder<Seller>
    {
        private static readonly List<Seller> sellers = new()
    {
        new Seller() {
            SellerId = 1,
            Name = "Seller One",
            Description = "Description for Seller One",
            PhoneNumber = "123-456-7890",
            Email = "sellerone@example.com",
            LocationId = 1, 
            SellerServiceCategories = new List<SellerServiceCategory>(),
            ServicePricings = new List<ServicePricing>()
        },
        new Seller()
        {
            SellerId = 2,
            Name = "Seller Two",
            Description = "Description for Seller Two",
            PhoneNumber = "987-654-3210",
            Email = "sellertwo@example.com",
            LocationId = 2, 
            SellerServiceCategories = new List<SellerServiceCategory>(),
            ServicePricings = new List<ServicePricing>()
        },
        new Seller()
        {
            SellerId = 3,
            Name = "Seller Three",
            Description = "Description for Seller Three",
            PhoneNumber = "555-555-5555",
            Email = "sellerthree@example.com",
            LocationId = 3, 
            SellerServiceCategories = new List<SellerServiceCategory>(),
            ServicePricings = new List<ServicePricing>()
        }
    };

        public void Seed(EntityTypeBuilder<Seller> builder)
        {
            foreach (var seller in sellers)
            {
                if (!builder.Metadata.GetSeedData().Any(s => (int)s["SellerId"] == seller.SellerId))
                {
                    builder.HasData(seller);
                }
            }
        }
    }

}
