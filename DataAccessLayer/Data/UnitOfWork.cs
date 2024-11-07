using Microsoft.EntityFrameworkCore;
using marketplace3.DataAccessLayer.Interfaces;
using marketplace3.DataAccessLayer.Entities;
using marketplace3.DataAccessLayer.Interfaces.Repositories;
using marketplace3.DataAccessLayer.Repositories;
using marketplace3.DataAccessLayer.Data.Repositories;

namespace marketplace3.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MarketplaceContext _context;

        public ISellerRepository Sellers { get; private set; }
        public ILocationRepository Locations { get; private set; }
        public IServiceCategoryRepository ServiceCategories { get; private set; }
        public ISellerServiceCategoryRepository SellerServiceCategories { get; private set; }
        public IServicePricingRepository ServicePricings { get; private set; }

        public UnitOfWork(MarketplaceContext context)
        {
            _context = context;
            Sellers = new SellerRepository(_context);
            Locations = new LocationRepository(_context);
            ServiceCategories = new ServiceCategoryRepository(_context);
            SellerServiceCategories = new SellerServiceCategoryRepository(_context);
            ServicePricings = new ServicePricingRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
