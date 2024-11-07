using AutoMapper;
using marketplace3.BusinessLogicLayer.DTO.Requests;
using marketplace3.BusinessLogicLayer.DTO.Responses;
using marketplace3.DataAccessLayer.Entities;

namespace marketplace3.BusinessLogicLayer.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateLocationMaps();
            CreateSellerMaps();
            CreateSellerServiceCategoryMaps();
            CreateServiceCategoryMaps();
            CreateServicePricingMaps();
        }

        private void CreateLocationMaps()
        {
            CreateMap<LocationRequest, Location>();
            CreateMap<Location, LocationResponse>();
        }

        private void CreateSellerMaps()
        {
            CreateMap<SellerRequest, Seller>().ReverseMap();
        }

        private void CreateSellerServiceCategoryMaps()
        {
            CreateMap<SellerServiceCategoryRequest, SellerServiceCategory>();
            CreateMap<SellerServiceCategory, SellerServiceCategoryResponse>()
                .ForMember(
                    response => response.SellerName,
                    options => options.MapFrom(ssc => ssc.Seller.Name))
                .ForMember(
                    response => response.ServiceCategoryName,
                    options => options.MapFrom(ssc => ssc.ServiceCategory.CategoryName));
        }

        private void CreateServiceCategoryMaps()
        {
            CreateMap<ServiceCategoryRequest, ServiceCategory>();
            CreateMap<ServiceCategory, ServiceCategoryResponse>();
        }

        private void CreateServicePricingMaps()
        {
            CreateMap<ServicePricingRequest, ServicePricing>();
            CreateMap<ServicePricing, ServicePricingResponse>();
        }
    }
}
