using marketplace3.DataAccessLayer.Entities;
using marketplace3.DataAccessLayer.Pagination;
using marketplace3.DataAccessLayer.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace marketplace3.DataAccessLayer.Interfaces.Repositories
{
    public interface IServicePricingRepository : IGenericRepository<ServicePricing>
    {
        Task<PagedList<ServicePricing>> GetPagedListAsync(ServicePricingsParameters parameters);
        Task<IEnumerable<ServicePricing>> GetBySellerIdAsync(int sellerId);
        Task<IEnumerable<ServicePricing>> GetByServiceNameAsync(string serviceName);
    }
}
