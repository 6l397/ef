using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using marketplace3.BusinessLogicLayer.DTO.Requests;
using marketplace3.BusinessLogicLayer.DTO.Responses;
using marketplace3.BusinessLogicLayer.Interfaces.Services;
using marketplace3.DataAccessLayer.Entities;
using marketplace3.DataAccessLayer.Exceptions;
using marketplace3.DataAccessLayer.Interfaces;
using marketplace3.DataAccessLayer.Pagination;
using marketplace3.DataAccessLayer.Parameters;
using Microsoft.EntityFrameworkCore;

namespace marketplace3.BusinessLogicLayer.Services
{
    public class SellerServiceCategoriesService : ISellerServiceCategoriesService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SellerServiceCategoriesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SellerServiceCategoryResponse>> GetAllAsync()
        {
            var sellerServiceCategories = await unitOfWork.SellerServiceCategories.GetAsync();
            return sellerServiceCategories.Select(mapper.Map<SellerServiceCategory, SellerServiceCategoryResponse>);
        }

        public async Task<PagedList<SellerServiceCategoryResponse>> GetAsync(SellerServiceCategoriesParameters parameters)
        {
            var sellerServiceCategories = await unitOfWork.SellerServiceCategories.GetAsync();
            var pagedResult = await PagedList<SellerServiceCategory>.ToPagedListAsync(sellerServiceCategories.AsQueryable(), parameters.PageNumber, parameters.PageSize);

            var serviceCategoryResponses = pagedResult.Map(item => mapper.Map<SellerServiceCategoryResponse>(item));

            return new PagedList<SellerServiceCategoryResponse>(
                serviceCategoryResponses,
                pagedResult.TotalEntitiesCount,
                pagedResult.CurrentPage,
                pagedResult.PageSize);
        }



        public async Task<SellerServiceCategoryResponse> GetByIdAsync(int sellerId, int serviceCategoryId)
        {
            // Custom query logic since GetCompleteEntityAsync takes only one ID.
            var sellerServiceCategory = await unitOfWork.SellerServiceCategories
                .FindAsync(sc => sc.SellerId == sellerId && sc.ServiceCategoryId == serviceCategoryId);

            if (sellerServiceCategory == null)
            {
                throw new EntityNotFoundException($"SellerServiceCategory with SellerId {sellerId} and ServiceCategoryId {serviceCategoryId} not found.");
            }

            return mapper.Map<SellerServiceCategory, SellerServiceCategoryResponse>(sellerServiceCategory);
        }

        public async Task AddAsync(SellerServiceCategoryRequest request)
        {
            var sellerServiceCategory = mapper.Map<SellerServiceCategoryRequest, SellerServiceCategory>(request);
            await unitOfWork.SellerServiceCategories.InsertAsync(sellerServiceCategory);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int sellerId, int serviceCategoryId, SellerServiceCategoryRequest request)
        {
            var sellerServiceCategory = await unitOfWork.SellerServiceCategories
                .FindAsync(sc => sc.SellerId == sellerId && sc.ServiceCategoryId == serviceCategoryId);

            if (sellerServiceCategory == null)
            {
                throw new EntityNotFoundException($"SellerServiceCategory with SellerId {sellerId} and ServiceCategoryId {serviceCategoryId} not found.");
            }

            mapper.Map(request, sellerServiceCategory);
            await unitOfWork.SellerServiceCategories.UpdateAsync(sellerServiceCategory);
            await unitOfWork.CompleteAsync();
        }



        public async Task DeleteAsync(int sellerId, int serviceCategoryId)
        {
            var sellerServiceCategory = await GetByIdAsync(sellerId, serviceCategoryId);
            await unitOfWork.SellerServiceCategories.DeleteAsync(sellerServiceCategory.SellerId);
            await unitOfWork.CompleteAsync();
        }
    }
}
