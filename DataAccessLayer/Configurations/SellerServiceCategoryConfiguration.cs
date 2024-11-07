using marketplace3.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace marketplace3.DataAccessLayer.Configurations
{
    public class SellerServiceCategoryConfiguration : IEntityTypeConfiguration<SellerServiceCategory>
    {
        public void Configure(EntityTypeBuilder<SellerServiceCategory> builder)
        {
            
            builder.HasKey(ssc => new { ssc.SellerId, ssc.ServiceCategoryId });

            
            builder.HasOne(ssc => ssc.Seller)
                .WithMany(s => s.SellerServiceCategories)
                .HasForeignKey(ssc => ssc.SellerId);

            builder.HasOne(ssc => ssc.ServiceCategory)
                .WithMany(sc => sc.SellerServiceCategories)
                .HasForeignKey(ssc => ssc.ServiceCategoryId);
        }
    }
}
