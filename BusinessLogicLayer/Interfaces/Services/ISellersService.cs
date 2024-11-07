using marketplace3.BusinessLogicLayer.DTO.Requests;
using marketplace3.BusinessLogicLayer.DTO.Responses;
using marketplace3.DataAccessLayer.Pagination;
using marketplace3.DataAccessLayer.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace marketplace3.BusinessLogicLayer.Interfaces.Services
{
    public interface ISellersService
    {
        Task<IEnumerable<SellerResponse>> GetAllAsync();
        Task<PagedList<SellerResponse>> GetAsync(SellersParameters parameters);
        Task<SellerResponse> GetByIdAsync(int id);
        Task AddAsync(SellerRequest request);
        Task UpdateAsync(int id, SellerRequest request);
        Task DeleteAsync(int id);
        Task<IEnumerable<ServicePricingResponse>> GetSellerPricingsAsync(int sellerId);
        Task<IEnumerable<SellerServiceCategoryResponse>> GetSellerServiceCategoriesAsync(int sellerId);
    }
}
