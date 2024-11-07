using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using marketplace3.DataAccessLayer.Entities;
using marketplace3.DataAccessLayer.Seeding;

namespace marketplace3.DataAccessLayer.Configurations
{
    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasKey(seller => seller.SellerId);

            builder.Property(seller => seller.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(seller => seller.Description)
                   .HasMaxLength(500);

            builder.Property(seller => seller.PhoneNumber)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(seller => seller.Email)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasOne(seller => seller.Location)
                   .WithMany()
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(seller => seller.SellerServiceCategories)
                   .WithOne(sellerServiceCategory => sellerServiceCategory.Seller)
                   .HasForeignKey(sellerServiceCategory => sellerServiceCategory.SellerId);

            builder.HasMany(seller => seller.ServicePricings)
                   .WithOne(servicePricing => servicePricing.Seller)
                   .HasForeignKey(servicePricing => servicePricing.SellerId);


            new SellerSeeder().Seed(builder);
        }
    }
}
