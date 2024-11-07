using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace3.DataAccessLayer.Entities;
using marketplace3.DataAccessLayer.Pagination;
using marketplace3.DataAccessLayer.Parameters;

namespace marketplace3.DataAccessLayer.Interfaces.Repositories
{
    public interface ISellerRepository : IGenericRepository<Seller>
    {
        Task<PagedList<Seller>> GetAsync(SellersParameters parameters);

        Task<IEnumerable<ServicePricing>> GetSellerPricingsAsync(int sellerId);

        Task<IEnumerable<SellerServiceCategory>> GetSellerServiceCategoriesAsync(int sellerId);
    }
}
