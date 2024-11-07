using marketplace3.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace marketplace3.DataAccessLayer.Interfaces.Repositories
{
    public interface ISellerServiceCategoryRepository : IGenericRepository<SellerServiceCategory>
    {
        Task<IEnumerable<SellerServiceCategory>> GetBySellerIdAsync(int sellerId);
        Task<IEnumerable<SellerServiceCategory>> GetByServiceCategoryIdAsync(int serviceCategoryId);
        Task<SellerServiceCategory> FindAsync(Func<SellerServiceCategory, bool> predicate);
    }
}
