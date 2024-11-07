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
    public class SellersController : ControllerBase
    {
        private readonly ISellersService _sellersService;
        private readonly IMapper _mapper;

        public SellersController(ISellersService sellersService, IMapper mapper)
        {
            _sellersService = sellersService;
            _mapper = mapper;
        }

        // GET: api/sellers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SellerResponse>>> GetSellers([FromQuery] SellersParameters parameters)
        {
            var sellers = await _sellersService.GetAsync(parameters);
            return Ok(sellers);
        }

        // GET: api/sellers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SellerResponse>> GetSellerById(int id)
        {
            try
            {
                var seller = await _sellersService.GetByIdAsync(id);
                return Ok(seller);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/sellers
        [HttpPost]
        public async Task<ActionResult> CreateSeller([FromBody] SellerRequest sellerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sellersService.AddAsync(sellerRequest);
            return CreatedAtAction(nameof(GetSellerById), new { id = sellerRequest.Name }, sellerRequest);
        }

        // PUT: api/sellers/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSeller(int id, [FromBody] SellerRequest sellerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _sellersService.UpdateAsync(id, sellerRequest);
                return NoContent();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/sellers/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSeller(int id)
        {
            try
            {
                await _sellersService.DeleteAsync(id);
                return NoContent();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // GET: api/sellers/{id}/pricings
        [HttpGet("{id}/pricings")]
        public async Task<ActionResult<IEnumerable<ServicePricingResponse>>> GetSellerPricings(int id)
        {
            try
            {
                var pricings = await _sellersService.GetSellerPricingsAsync(id);
                return Ok(pricings);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // GET: api/sellers/{id}/servicecategories
        [HttpGet("{id}/servicecategories")]
        public async Task<ActionResult<IEnumerable<SellerServiceCategoryResponse>>> GetSellerServiceCategories(int id)
        {
            try
            {
                var categories = await _sellersService.GetSellerServiceCategoriesAsync(id);
                return Ok(categories);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
