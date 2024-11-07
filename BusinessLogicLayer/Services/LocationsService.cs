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
using marketplace3.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace marketplace3.BusinessLogicLayer.Services
{
    public class LocationsService : ILocationsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public LocationsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<LocationResponse>> GetAllAsync()
        {
            var locations = await unitOfWork.Locations.GetAsync();
            return locations.Select(mapper.Map<Location, LocationResponse>);
        }

        public async Task<PagedList<LocationResponse>> GetAsync(LocationsParameters parameters)
        {
            var locations = await unitOfWork.Locations.GetAsync(parameters);
            return locations.Map(mapper.Map<Location, LocationResponse>);
        }

        public async Task<LocationResponse> GetByIdAsync(int id)
        {
            var location = await unitOfWork.Locations.GetCompleteEntityAsync(id);
            return mapper.Map<Location, LocationResponse>(location);
        }

        public async Task AddAsync(LocationRequest request)
        {
            var location = mapper.Map<LocationRequest, Location>(request);
            await unitOfWork.Locations.InsertAsync(location);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int id, LocationRequest request)
        {
            var location = await unitOfWork.Locations.GetByIdAsync(id);
            if (location == null)
            {
                throw new EntityNotFoundException($"Location with ID {id} not found.");
            }

            mapper.Map(request, location);
            await unitOfWork.Locations.UpdateAsync(location);
            await unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var location = await unitOfWork.Locations.GetByIdAsync(id);
            if (location == null)
            {
                throw new EntityNotFoundException($"Location with ID {id} not found.");
            }

            await unitOfWork.Locations.DeleteAsync(id);
            await unitOfWork.CompleteAsync();
        }
    }

}
