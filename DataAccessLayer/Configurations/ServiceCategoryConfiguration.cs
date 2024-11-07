using marketplace3.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace marketplace3.DataAccessLayer.Configurations
{
    public class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
           
            builder.HasKey(sc => sc.ServiceCategoryId);

            
            builder.Property(sc => sc.CategoryName)
                .IsRequired() 
                .HasMaxLength(100); 

           
            builder.HasMany(sc => sc.SellerServiceCategories)
                .WithOne(ssc => ssc.ServiceCategory)
                .HasForeignKey(ssc => ssc.ServiceCategoryId);

            
        }
    }
}
