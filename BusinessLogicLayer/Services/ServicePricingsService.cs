using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using marketplace3.BusinessLogicLayer.DTO.Requests;
using marketplace3.BusinessLogicLayer.DTO.Responses;
using marketplace3.BusinessLogicLayer.Interfaces.Services;
using marketplace3.DataAccessLayer.Entities;
using marketplace3.DataAccessLayer.Interfaces.Repositories;
using marketplace3.DataAccessLayer.Pagination;
using marketplace3.DataAccessLayer.Parameters;

namespace marketplace3.BusinessLogicLayer.Services
{
    public class ServicePricingsService : IServicePricingsService
    {
        private readonly IServicePricingRepository _servicePricingRepository;
        private readonly IMapper _mapper;

        public ServicePricingsService(IServicePricingRepository servicePricingRepository, IMapper mapper)
        {
            _servicePricingRepository = servicePricingRepository;
            _mapper = mapper;
        }

        public async Task<ServicePricingResponse> GetServicePricingByIdAsync(int servicePricingId)
        {
            var servicePricing = await _servicePricingRepository.GetCompleteEntityAsync(servicePricingId);
            return _mapper.Map<ServicePricingResponse>(servicePricing);
        }

        public async Task<PagedList<ServicePricingResponse>> GetServicePricingsAsync(ServicePricingsParameters parameters)
        {
            var servicePricings = await _servicePricingRepository.GetPagedListAsync(parameters);
            return servicePricings.Map(sp => _mapper.Map<ServicePricingResponse>(sp));
        }

        public async Task<IEnumerable<ServicePricingResponse>> GetServicePricingsBySellerIdAsync(int sellerId)
        {
            var servicePricings = await _servicePricingRepository.GetBySellerIdAsync(sellerId);
            return servicePricings.Select(sp => _mapper.Map<ServicePricingResponse>(sp));
        }

        public async Task<IEnumerable<ServicePricingResponse>> GetServicePricingsByServiceNameAsync(string serviceName)
        {
            var servicePricings = await _servicePricingRepository.GetByServiceNameAsync(serviceName);
            return servicePricings.Select(sp => _mapper.Map<ServicePricingResponse>(sp));
        }

        public async Task<ServicePricingResponse> CreateServicePricingAsync(ServicePricingRequest request)
        {
            var servicePricing = _mapper.Map<ServicePricing>(request);
            await _servicePricingRepository.InsertAsync(servicePricing);
            return _mapper.Map<ServicePricingResponse>(servicePricing);
        }

        public async Task UpdateServicePricingAsync(int servicePricingId, ServicePricingRequest request)
        {
            var servicePricing = await _servicePricingRepository.GetCompleteEntityAsync(servicePricingId);
            _mapper.Map(request, servicePricing);
            await _servicePricingRepository.UpdateAsync(servicePricing);
        }

        public async Task DeleteServicePricingAsync(int servicePricingId)
        {
            await _servicePricingRepository.DeleteAsync(servicePricingId);
        }
    }
}
