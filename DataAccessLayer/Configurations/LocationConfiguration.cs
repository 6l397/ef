using marketplace3.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace marketplace3.DataAccessLayer.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
           
            builder.HasKey(l => l.LocationId);

            builder.Property(l => l.City)
                .IsRequired() 
                .HasMaxLength(100); 

            builder.Property(l => l.StreetAddress)
                .IsRequired() 
                .HasMaxLength(200); 
        }
    }
}
