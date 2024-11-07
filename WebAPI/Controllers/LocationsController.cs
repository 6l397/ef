using AutoMapper;
using marketplace3.BusinessLogicLayer.DTO.Requests;
using marketplace3.BusinessLogicLayer.DTO.Responses;
using marketplace3.BusinessLogicLayer.Interfaces.Services;
using marketplace3.DataAccessLayer.Exceptions;
using marketplace3.DataAccessLayer.Parameters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace marketplace3.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationsService locationsService;
        private readonly IMapper mapper;

        public LocationsController(ILocationsService locationsService, IMapper mapper)
        {
            this.locationsService = locationsService;
            this.mapper = mapper;
        }

        // GET: api/locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationResponse>>> GetLocations([FromQuery] LocationsParameters parameters)
        {
            var locations = await locationsService.GetAsync(parameters);
            return Ok(locations);
        }

        // GET: api/locations/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationResponse>> GetLocation(int id)
        {
            var location = await locationsService.GetByIdAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        // POST: api/locations
        [HttpPost]
        public async Task<ActionResult> CreateLocation([FromBody] LocationRequest request)
        {
            await locationsService.AddAsync(request);
            return CreatedAtAction(nameof(GetLocation), new { id = request.City }, request);
        }

        // PUT: api/locations/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLocation(int id, [FromBody] LocationRequest request)
        {
            try
            {
                await locationsService.UpdateAsync(id, request);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/locations/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLocation(int id)
        {
            try
            {
                await locationsService.DeleteAsync(id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
