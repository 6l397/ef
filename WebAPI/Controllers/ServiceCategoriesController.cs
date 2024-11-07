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
    public class ServiceCategoriesController : ControllerBase
    {
        private readonly IServiceCategoriesService _serviceCategoriesService;
        private readonly IMapper _mapper;

        public ServiceCategoriesController(IServiceCategoriesService serviceCategoriesService, IMapper mapper)
        {
            _serviceCategoriesService = serviceCategoriesService;
            _mapper = mapper;
        }

        // GET: api/ServiceCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceCategoryResponse>>> GetAll()
        {
            var serviceCategories = await _serviceCategoriesService.GetAllAsync();
            return Ok(serviceCategories);
        }

        // GET: api/ServiceCategories/paged
        [HttpGet("paged")]
        public async Task<ActionResult<IEnumerable<ServiceCategoryResponse>>> GetPaged([FromQuery] ServiceCategoriesParameters parameters)
        {
            var pagedResult = await _serviceCategoriesService.GetAsync(parameters);
            return Ok(pagedResult);
        }

        // GET: api/ServiceCategories/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceCategoryResponse>> GetById(int id)
        {
            var serviceCategory = await _serviceCategoriesService.GetByIdAsync(id);
            if (serviceCategory == null)
            {
                return NotFound();
            }

            return Ok(serviceCategory);
        }

        // GET: api/ServiceCategories/name?categoryName={categoryName}
        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<ServiceCategoryResponse>>> GetByCategoryName([FromQuery] string categoryName)
        {
            var serviceCategories = await _serviceCategoriesService.GetByCategoryNameAsync(categoryName);
            return Ok(serviceCategories);
        }

        // POST: api/ServiceCategories
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ServiceCategoryRequest request)
        {
            await _serviceCategoriesService.AddAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = request.CategoryName }, request);
        }

        // PUT: api/ServiceCategories/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ServiceCategoryRequest request)
        {
            await _serviceCategoriesService.UpdateAsync(id, request);
            return NoContent();
        }

        // DELETE: api/ServiceCategories/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceCategoriesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
