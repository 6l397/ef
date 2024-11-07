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
    public class ServiceCategoriesService : IServiceCategoriesService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ServiceCategoriesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ServiceCategoryResponse>> GetAllAsync()
        {
            var serviceCategories = await unitOfWork.ServiceCategories.GetAsync();
            return serviceCategories.Select(mapper.Map<ServiceCategory, ServiceCategoryResponse>);
        }

        public async Task<PagedList<ServiceCategoryResponse>> GetAsync(ServiceCategoriesParameters parameters)
        {
            var serviceCategories = await unitOfWork.ServiceCategories.GetAsync();
            var pagedResult = await PagedList<ServiceCategory>.ToPagedListAsync(serviceCategories.AsQueryable(), parameters.PageNumber, parameters.PageSize);
            var serviceCategoryResponses = pagedResult.Map(sc => mapper.Map<ServiceCategoryResponse>(sc));
            return serviceCategoryResponses;
        }

        public async Task<ServiceCategoryResponse> GetByIdAsync(int serviceCategoryId)
        {
            var serviceCategory = await unitOfWork.ServiceCategories.GetCompleteEntityAsync(serviceCategoryId);
            return mapper.Map<ServiceCategory, ServiceCategoryResponse>(serviceCategory);
        }

        public async Task<IEnumerable<ServiceCategoryResponse>> GetByCategoryNameAsync(string categoryName)
        {
            var serviceCategories = await unitOfWork.ServiceCategories.GetByCategoryNameAsync(categoryName);
            return serviceCategories.Select(mapper.Map<ServiceCategory, ServiceCategoryResponse>);
        }

        public async Task AddAsync(ServiceCategoryRequest request)
        {
            var serviceCategory = mapper.Map<ServiceCategoryRequest, ServiceCategory>(request);
            await unitOfWork.ServiceCategories.InsertAsync(serviceCategory);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int serviceCategoryId, ServiceCategoryRequest request)
        {
            var serviceCategory = await unitOfWork.ServiceCategories.GetCompleteEntityAsync(serviceCategoryId);
            mapper.Map(request, serviceCategory);
            await unitOfWork.ServiceCategories.UpdateAsync(serviceCategory);
            await unitOfWork.CompleteAsync();
        }


        public async Task DeleteAsync(int serviceCategoryId)
        {
            var serviceCategory = await GetByIdAsync(serviceCategoryId);
            await unitOfWork.ServiceCategories.DeleteAsync(serviceCategoryId);
            await unitOfWork.CompleteAsync();
        }
    }
}
