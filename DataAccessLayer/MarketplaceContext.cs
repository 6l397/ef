using marketplace3.DataAccessLayer.Entities;
using marketplace3.DataAccessLayer.Configurations;
using Microsoft.EntityFrameworkCore;
using marketplace3.DataAccessLayer.Seeding;

namespace marketplace3.DataAccessLayer
{
    public class MarketplaceContext : DbContext
    {
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<SellerServiceCategory> SellerServiceCategories { get; set; }
        public DbSet<ServicePricing> ServicePricings { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            new LocationSeeder().Seed(modelBuilder.Entity<Location>());
            modelBuilder.ApplyConfiguration(new SellerConfiguration());
            new SellerSeeder().Seed(modelBuilder.Entity<Seller>());
            modelBuilder.ApplyConfiguration(new ServiceCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SellerServiceCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ServicePricingConfiguration());
          
        }

        public MarketplaceContext(DbContextOptions<MarketplaceContext> options)
            : base(options)
        {
            var builder = new DbContextOptionsBuilder<MarketplaceContext>(options);
            builder.EnableSensitiveDataLogging();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
