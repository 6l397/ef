using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace3.BusinessLogicLayer.DTO.Requests;
using marketplace3.BusinessLogicLayer.DTO.Responses;
using marketplace3.DataAccessLayer.Pagination;
using marketplace3.DataAccessLayer.Parameters;

namespace marketplace3.BusinessLogicLayer.Interfaces.Services
{
    public interface ILocationsService
    {
        Task<IEnumerable<LocationResponse>> GetAllAsync(); 

        Task<PagedList<LocationResponse>> GetAsync(LocationsParameters parameters);

        Task<LocationResponse> GetByIdAsync(int id);

        Task AddAsync(LocationRequest request); 

        Task UpdateAsync(int id, LocationRequest request);

        Task DeleteAsync(int id);
    }
}
