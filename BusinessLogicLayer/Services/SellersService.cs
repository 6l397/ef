using AutoMapper;
using marketplace3.BusinessLogicLayer.DTO.Requests;
using marketplace3.BusinessLogicLayer.DTO.Responses;
using marketplace3.BusinessLogicLayer.Interfaces.Services;
using marketplace3.DataAccessLayer.Entities;
using marketplace3.DataAccessLayer.Exceptions;
using marketplace3.DataAccessLayer.Interfaces;
using marketplace3.DataAccessLayer.Pagination;
using marketplace3.DataAccessLayer.Parameters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketplace3.BusinessLogicLayer.Services
{
    public class SellersService : ISellersService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SellersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SellerResponse>> GetAllAsync()
        {
            var sellers = await unitOfWork.Sellers.GetAsync();
            return sellers.Select(mapper.Map<Seller, SellerResponse>);
        }

        public async Task<PagedList<SellerResponse>> GetAsync(SellersParameters parameters)
        {
            var sellers = await unitOfWork.Sellers.GetAsync(parameters);
            return sellers.Map(mapper.Map<Seller, SellerResponse>);
        }

        public async Task<SellerResponse> GetByIdAsync(int id)
        {
            var seller = await unitOfWork.Sellers.GetCompleteEntityAsync(id);
            return mapper.Map<Seller, SellerResponse>(seller);
        }

        public async Task AddAsync(SellerRequest request)
        {
            var seller = mapper.Map<SellerRequest, Seller>(request);
            await unitOfWork.Sellers.InsertAsync(seller);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, SellerRequest request)
        {
            var seller = await unitOfWork.Sellers.GetByIdAsync(id);
            if (seller == null)
            {
                throw new EntityNotFoundException($"Seller with ID {id} not found.");
            }

            mapper.Map(request, seller);
            await unitOfWork.Sellers.UpdateAsync(seller);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var seller = await unitOfWork.Sellers.GetByIdAsync(id);
            if (seller == null)
            {
                throw new EntityNotFoundException($"Seller with ID {id} not found.");
            }

            await unitOfWork.Sellers.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<ServicePricingResponse>> GetSellerPricingsAsync(int sellerId)
        {
            var pricings = await unitOfWork.Sellers.GetSellerPricingsAsync(sellerId);
            return pricings.Select(mapper.Map<ServicePricing, ServicePricingResponse>);
        }

        public async Task<IEnumerable<SellerServiceCategoryResponse>> GetSellerServiceCategoriesAsync(int sellerId)
        {
            var categories = await unitOfWork.Sellers.GetSellerServiceCategoriesAsync(sellerId);
            return categories.Select(mapper.Map<SellerServiceCategory, SellerServiceCategoryResponse>);
        }
    }
}
