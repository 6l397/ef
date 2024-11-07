using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace marketplace3.DataAccessLayer
{
    public class ContextFactory : IDesignTimeDbContextFactory<MarketplaceContext>
    {
        public MarketplaceContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MarketplaceContext>();
            optionsBuilder.UseMySQL(config.GetConnectionString("DefaultConnection")); 

            return new MarketplaceContext(optionsBuilder.Options);
        }
    }
}
