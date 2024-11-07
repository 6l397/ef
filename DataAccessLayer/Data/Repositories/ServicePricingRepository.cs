using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using marketplace3.DataAccessLayer.Entities;
using marketplace3.DataAccessLayer.Interfaces.Repositories;
using marketplace3.DataAccessLayer.Exceptions;
using marketplace3.DataAccessLayer.Pagination;
using marketplace3.DataAccessLayer.Parameters;

namespace marketplace3.DataAccessLayer.Repositories
{
    public class ServicePricingRepository : GenericRepository<ServicePricing>, IServicePricingRepository
    {
        public ServicePricingRepository(MarketplaceContext databaseContext) : base(databaseContext)
        {
        }

        public override async Task<ServicePricing> GetCompleteEntityAsync(int servicePricingId)
        {
            return await table
                .Include(sp => sp.Seller)
                .FirstOrDefaultAsync(sp => sp.ServicePricingId == servicePricingId)
                ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(servicePricingId));
        }

        public async Task<IEnumerable<ServicePricing>> GetBySellerIdAsync(int sellerId)
        {
            return await table
                .Where(sp => sp.SellerId == sellerId)
                .Include(sp => sp.Seller)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServicePricing>> GetByServiceNameAsync(string serviceName)
        {
            return await table
                .Where(sp => sp.ServiceName.Contains(serviceName))
                .Include(sp => sp.Seller)
                .ToListAsync();
        }
        public async Task<PagedList<ServicePricing>> GetPagedListAsync(ServicePricingsParameters parameters)
        {
            var query = databaseContext.ServicePricings.AsQueryable();

            // Додайте логіку фільтрації чи сортування за потреби

            return await PagedList<ServicePricing>.ToPagedListAsync(query, parameters.PageNumber, parameters.PageSize);
        }
    }
}
