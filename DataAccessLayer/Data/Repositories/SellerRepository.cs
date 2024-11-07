using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using marketplace3.DataAccessLayer.Entities;
using marketplace3.DataAccessLayer.Exceptions;
using marketplace3.DataAccessLayer.Interfaces.Repositories;
using marketplace3.DataAccessLayer.Pagination;
using marketplace3.DataAccessLayer.Parameters;
using marketplace3.DataAccessLayer.Repositories;

namespace marketplace3.DataAccessLayer.Data.Repositories
{
    public class SellerRepository : GenericRepository<Seller>, ISellerRepository
    {
        public SellerRepository(MarketplaceContext databaseContext) : base(databaseContext) { }

        public override async Task<Seller> GetCompleteEntityAsync(int id)
        {
            var seller = await table.Include(s => s.Location)
                                    .Include(s => s.ServicePricings)
                                    .Include(s => s.SellerServiceCategories)
                                    .SingleOrDefaultAsync(s => s.SellerId == id);

            return seller ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        public async Task<PagedList<Seller>> GetAsync(SellersParameters parameters)
        {
            IQueryable<Seller> source = table.Include(s => s.Location);

            SearchByName(ref source, parameters.Name);
            SearchByLocation(ref source, parameters.City);

            return await PagedList<Seller>.ToPagedListAsync(
                source,
                parameters.PageNumber,
                parameters.PageSize);
        }

        public async Task<IEnumerable<ServicePricing>> GetSellerPricingsAsync(int sellerId)
        {
            var seller = await table.Include(s => s.ServicePricings)
                                    .SingleOrDefaultAsync(s => s.SellerId == sellerId);

            if (seller == null)
                throw new EntityNotFoundException($"Seller with ID {sellerId} not found.");

            return seller.ServicePricings;
        }

        public async Task<IEnumerable<SellerServiceCategory>> GetSellerServiceCategoriesAsync(int sellerId)
        {
            var seller = await table.Include(s => s.SellerServiceCategories)
                                    .SingleOrDefaultAsync(s => s.SellerId == sellerId);

            if (seller == null)
                throw new EntityNotFoundException($"Seller with ID {sellerId} not found.");

            return seller.SellerServiceCategories;
        }

        private static void SearchByName(ref IQueryable<Seller> source, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            source = source.Where(s => s.Name.Contains(name));
        }

        private static void SearchByLocation(ref IQueryable<Seller> source, string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                return;

            source = source.Where(s => s.Location.City.Contains(city));
        }
    }
}
