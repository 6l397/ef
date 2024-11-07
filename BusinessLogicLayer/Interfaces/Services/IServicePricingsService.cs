using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace3.BusinessLogicLayer.DTO.Requests;
using marketplace3.BusinessLogicLayer.DTO.Responses;
using marketplace3.DataAccessLayer.Pagination;
using marketplace3.DataAccessLayer.Parameters;

namespace marketplace3.BusinessLogicLayer.Interfaces.Services
{
    public interface IServicePricingsService
    {
        Task<ServicePricingResponse> GetServicePricingByIdAsync(int servicePricingId);
        Task<PagedList<ServicePricingResponse>> GetServicePricingsAsync(ServicePricingsParameters parameters);
        Task<IEnumerable<ServicePricingResponse>> GetServicePricingsBySellerIdAsync(int sellerId);
        Task<IEnumerable<ServicePricingResponse>> GetServicePricingsByServiceNameAsync(string serviceName);
        Task<ServicePricingResponse> CreateServicePricingAsync(ServicePricingRequest request);
        Task UpdateServicePricingAsync(int servicePricingId, ServicePricingRequest request);
        Task DeleteServicePricingAsync(int servicePricingId);
    }
}
