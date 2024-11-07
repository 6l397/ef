using marketplace3.BusinessLogicLayer.DTO.Requests;
using marketplace3.BusinessLogicLayer.DTO.Responses;
using marketplace3.DataAccessLayer.Pagination;
using marketplace3.DataAccessLayer.Parameters;

namespace marketplace3.BusinessLogicLayer.Interfaces.Services
{
    public interface ISellerServiceCategoriesService
    {
        Task<IEnumerable<SellerServiceCategoryResponse>> GetAllAsync();
        Task<PagedList<SellerServiceCategoryResponse>> GetAsync(SellerServiceCategoriesParameters parameters);
        Task<SellerServiceCategoryResponse> GetByIdAsync(int sellerId, int serviceCategoryId);
        Task AddAsync(SellerServiceCategoryRequest request);
        Task UpdateAsync(int sellerId, int serviceCategoryId, SellerServiceCategoryRequest request);
        Task DeleteAsync(int sellerId, int serviceCategoryId);
    }
}
