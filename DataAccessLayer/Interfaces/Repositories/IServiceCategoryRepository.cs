using marketplace3.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace marketplace3.DataAccessLayer.Interfaces.Repositories
{
    public interface IServiceCategoryRepository : IGenericRepository<ServiceCategory>
    {
        Task<IEnumerable<ServiceCategory>> GetByCategoryNameAsync(string categoryName);
    }
}
