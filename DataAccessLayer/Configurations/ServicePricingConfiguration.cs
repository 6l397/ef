using marketplace3.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace marketplace3.DataAccessLayer.Configurations
{
    public class ServicePricingConfiguration : IEntityTypeConfiguration<ServicePricing>
    {
        public void Configure(EntityTypeBuilder<ServicePricing> builder)
        {
            builder.HasKey(sp => sp.ServicePricingId);

            builder.HasOne(sp => sp.Seller)
                .WithMany(s => s.ServicePricings)
                .HasForeignKey(sp => sp.SellerId)
                .OnDelete(DeleteBehavior.Cascade); 

            
            builder.Property(sp => sp.ServiceName)
                .IsRequired()
                .HasMaxLength(100); 

            builder.Property(sp => sp.Price)
                .IsRequired() 
                .HasColumnType("decimal(18,2)"); 
        }
    }
}
