using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using marketplace3.BusinessLogicLayer.DTO.Requests;
using marketplace3.BusinessLogicLayer.DTO.Responses;
using marketplace3.BusinessLogicLayer.Interfaces.Services;
using marketplace3.DataAccessLayer.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace marketplace3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePricingsController : ControllerBase
    {
        private readonly IServicePricingsService _servicePricingsService;
        private readonly IMapper _mapper;

        public ServicePricingsController(IServicePricingsService servicePricingsService, IMapper mapper)
        {
            _servicePricingsService = servicePricingsService;
            _mapper = mapper;
        }

        // GET: api/ServicePricings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicePricingResponse>>> GetServicePricings([FromQuery] ServicePricingsParameters parameters)
        {
            var servicePricings = await _servicePricingsService.GetServicePricingsAsync(parameters);
            return Ok(servicePricings);
        }

        // GET: api/ServicePricings/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicePricingResponse>> GetServicePricingById(int id)
        {
            var servicePricing = await _servicePricingsService.GetServicePricingByIdAsync(id);

            if (servicePricing == null)
                return NotFound();

            return Ok(servicePricing);
        }

        // GET: api/ServicePricings/Seller/{sellerId}
        [HttpGet("Seller/{sellerId}")]
        public async Task<ActionResult<IEnumerable<ServicePricingResponse>>> GetServicePricingsBySellerId(int sellerId)
        {
            var servicePricings = await _servicePricingsService.GetServicePricingsBySellerIdAsync(sellerId);
            return Ok(servicePricings);
        }

        // GET: api/ServicePricings/ServiceName
        [HttpGet("ServiceName/{serviceName}")]
        public async Task<ActionResult<IEnumerable<ServicePricingResponse>>> GetServicePricingsByServiceName(string serviceName)
        {
            var servicePricings = await _servicePricingsService.GetServicePricingsByServiceNameAsync(serviceName);
            return Ok(servicePricings);
        }

        // POST: api/ServicePricings
        [HttpPost]
        public async Task<ActionResult<ServicePricingResponse>> CreateServicePricing(ServicePricingRequest request)
        {
            var servicePricing = await _servicePricingsService.CreateServicePricingAsync(request);
            return CreatedAtAction(nameof(GetServicePricingById), new { id = servicePricing.ServicePricingId }, servicePricing);
        }

        // PUT: api/ServicePricings/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServicePricing(int id, ServicePricingRequest request)
        {
            await _servicePricingsService.UpdateServicePricingAsync(id, request);
            return NoContent();
        }

        // DELETE: api/ServicePricings/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicePricing(int id)
        {
            await _servicePricingsService.DeleteServicePricingAsync(id);
            return NoContent();
        }
    }
}
