using marketplace3.DataAccessLayer.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace marketplace3.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISellerRepository Sellers { get; }
        ILocationRepository Locations { get; }
        IServiceCategoryRepository ServiceCategories { get; }
        ISellerServiceCategoryRepository SellerServiceCategories { get; }
        IServicePricingRepository ServicePricings { get; }

        Task<int> CompleteAsync(); 
    }
}
