using marketplace3.DataAccessLayer.Entities;
using marketplace3.DataAccessLayer.Pagination;
using marketplace3.DataAccessLayer.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace marketplace3.DataAccessLayer.Interfaces.Repositories
{
    public interface ILocationRepository : IGenericRepository<Location>
    {
        Task<IEnumerable<Location>> GetLocationsByCityAsync(string city);
        Task<PagedList<Location>> GetAsync(LocationsParameters parameters);
    }
}
