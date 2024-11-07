using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using marketplace3.DataAccessLayer.Entities;
using marketplace3.DataAccessLayer.Interfaces.Repositories;
using marketplace3.DataAccessLayer.Exceptions;

namespace marketplace3.DataAccessLayer.Repositories
{
    public class SellerServiceCategoryRepository : GenericRepository<SellerServiceCategory>, ISellerServiceCategoryRepository
    {
        public SellerServiceCategoryRepository(MarketplaceContext databaseContext) : base(databaseContext)
        {
        }

        public override async Task<SellerServiceCategory> GetCompleteEntityAsync(int sellerId)
        {
            return await table
                .Include(ssc => ssc.Seller)
                .Include(ssc => ssc.ServiceCategory)
                .FirstOrDefaultAsync(ssc => ssc.SellerId == sellerId)
                ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(sellerId));
        }

        public async Task<IEnumerable<SellerServiceCategory>> GetBySellerIdAsync(int sellerId)
        {
            return await table
                .Where(ssc => ssc.SellerId == sellerId)
                .Include(ssc => ssc.ServiceCategory)
                .ToListAsync();
        }

        public async Task<IEnumerable<SellerServiceCategory>> GetByServiceCategoryIdAsync(int serviceCategoryId)
        {
            return await table
                .Where(ssc => ssc.ServiceCategoryId == serviceCategoryId)
                .Include(ssc => ssc.Seller)
                .ToListAsync();
        }
        public async Task<SellerServiceCategory> FindAsync(Func<SellerServiceCategory, bool> predicate)
        {
            return await Task.Run(() => table.FirstOrDefault(predicate));
        }
    }
}
