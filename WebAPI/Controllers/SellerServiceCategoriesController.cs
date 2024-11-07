using AutoMapper;
using marketplace3.BusinessLogicLayer.DTO.Requests;
using marketplace3.BusinessLogicLayer.DTO.Responses;
using marketplace3.BusinessLogicLayer.Interfaces.Services;
using marketplace3.DataAccessLayer.Parameters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace marketplace3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerServiceCategoriesController : ControllerBase
    {
        private readonly ISellerServiceCategoriesService _sellerServiceCategoriesService;
        private readonly IMapper _mapper;

        public SellerServiceCategoriesController(
            ISellerServiceCategoriesService sellerServiceCategoriesService,
            IMapper mapper)
        {
            _sellerServiceCategoriesService = sellerServiceCategoriesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SellerServiceCategoryResponse>>> GetAllAsync()
        {
            var categories = await _sellerServiceCategoriesService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("paged")]
        public async Task<ActionResult> GetPagedAsync([FromQuery] SellerServiceCategoriesParameters parameters)
        {
            var pagedCategories = await _sellerServiceCategoriesService.GetAsync(parameters);
            return Ok(new { pagedCategories.Metadata, pagedCategories });
        }

        [HttpGet("{sellerId:int}/{serviceCategoryId:int}")]
        public async Task<ActionResult<SellerServiceCategoryResponse>> GetByIdAsync(int sellerId, int serviceCategoryId)
        {
            var category = await _sellerServiceCategoriesService.GetByIdAsync(sellerId, serviceCategoryId);
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] SellerServiceCategoryRequest request)
        {
            await _sellerServiceCategoriesService.AddAsync(request);
            return CreatedAtAction(nameof(GetByIdAsync), new { request.SellerId, request.ServiceCategoryId }, request);
        }

        [HttpPut("{sellerId:int}/{serviceCategoryId:int}")]
        public async Task<ActionResult> UpdateAsync(int sellerId, int serviceCategoryId, [FromBody] SellerServiceCategoryRequest request)
        {
            await _sellerServiceCategoriesService.UpdateAsync(sellerId, serviceCategoryId, request);
            return NoContent();
        }

        [HttpDelete("{sellerId:int}/{serviceCategoryId:int}")]
        public async Task<ActionResult> DeleteAsync(int sellerId, int serviceCategoryId)
        {
            await _sellerServiceCategoriesService.DeleteAsync(sellerId, serviceCategoryId);
            return NoContent();
        }
    }
}
