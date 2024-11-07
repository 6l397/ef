using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using marketplace3.DataAccessLayer.Entities;
using marketplace3.DataAccessLayer.Interfaces.Repositories;
using marketplace3.DataAccessLayer.Exceptions;
using marketplace3.DataAccessLayer.Pagination;
using marketplace3.DataAccessLayer.Parameters;

namespace marketplace3.DataAccessLayer.Repositories
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(MarketplaceContext databaseContext) : base(databaseContext)
        {
        }

        public override async Task<Location> GetCompleteEntityAsync(int id)
        {
            return await table
                .FirstOrDefaultAsync(l => l.LocationId == id)
                ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }


        public async Task<PagedList<Location>> GetAsync(LocationsParameters parameters)
        {
            var query = table.AsQueryable();

            
            if (!string.IsNullOrWhiteSpace(parameters.City))
            {
                query = query.Where(l => l.City == parameters.City);
            }

            return await PagedList<Location>.ToPagedListAsync(query, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<IEnumerable<Location>> GetLocationsByCityAsync(string city)
        {
            return await table.Where(l => l.City == city).ToListAsync();
        }
    }
}
