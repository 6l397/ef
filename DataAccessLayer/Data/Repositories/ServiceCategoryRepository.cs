using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using marketplace3.DataAccessLayer.Entities;
using marketplace3.DataAccessLayer.Interfaces.Repositories;
using marketplace3.DataAccessLayer.Exceptions;

namespace marketplace3.DataAccessLayer.Repositories
{
    public class ServiceCategoryRepository : GenericRepository<ServiceCategory>, IServiceCategoryRepository
    {
        public ServiceCategoryRepository(MarketplaceContext databaseContext) : base(databaseContext)
        {
        }

        public override async Task<ServiceCategory> GetCompleteEntityAsync(int serviceCategoryId)
        {
            return await table
                .Include(sc => sc.SellerServiceCategories)
                .ThenInclude(ssc => ssc.Seller)
                .FirstOrDefaultAsync(sc => sc.ServiceCategoryId == serviceCategoryId)
                ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(serviceCategoryId));
        }

        public async Task<IEnumerable<ServiceCategory>> GetByCategoryNameAsync(string categoryName)
        {
            return await table
                .Where(sc => sc.CategoryName.Contains(categoryName))
                .Include(sc => sc.SellerServiceCategories)
                .ThenInclude(ssc => ssc.Seller)
                .ToListAsync();
        }
    }
}
