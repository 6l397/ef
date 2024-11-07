using marketplace3.BusinessLogicLayer.DTO.Requests;
using marketplace3.BusinessLogicLayer.DTO.Responses;
using marketplace3.DataAccessLayer.Pagination;
using marketplace3.DataAccessLayer.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace marketplace3.BusinessLogicLayer.Interfaces.Services
{
    public interface IServiceCategoriesService
    {
        Task<IEnumerable<ServiceCategoryResponse>> GetAllAsync();
        Task<PagedList<ServiceCategoryResponse>> GetAsync(ServiceCategoriesParameters parameters);
        Task<ServiceCategoryResponse> GetByIdAsync(int serviceCategoryId);
        Task<IEnumerable<ServiceCategoryResponse>> GetByCategoryNameAsync(string categoryName);
        Task AddAsync(ServiceCategoryRequest request);
        Task UpdateAsync(int serviceCategoryId, ServiceCategoryRequest request);
        Task DeleteAsync(int serviceCategoryId);
    }
}
