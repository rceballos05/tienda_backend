using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tienda.Application.Dtos.Requests;
using Tienda.Application.Interfaces;
using Tienda.Infrastructure.Commons.Bases.Requests;

namespace Tienda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplication categoryApplication;
        public CategoryController(ICategoryApplication _categoryApplication)
        {
            categoryApplication = _categoryApplication;
        }
        [HttpPost("list-categories")]
        public async Task<IActionResult> ListCategories([FromBody] BaseFilterRequest filter)
        {
            var response = await categoryApplication.ListCategory(filter);
            return Ok(response);
        }
        [HttpGet("list-category/{id:int}")]
        public async Task<IActionResult> CategoryByID(int id)
        {
            var response = await categoryApplication.CategoryById(id);
            return Ok(response);
        }
        [HttpPost("register-category")]
        public async Task<IActionResult> RegisterCategory([FromBody] CategoryDtoRequest categoryDto)
        {
            var response = await categoryApplication.RegisterCategory(categoryDto);
            return Ok(response);
        }
        [HttpPut("edit-category/{id:int}")]
        public async Task<IActionResult> EditCategory(int id, [FromBody] CategoryDtoRequest categoryDto)
        {
            var response = await categoryApplication.EditCategory(id, categoryDto);
            return Ok(response);
        }
        [HttpDelete("delete-category/{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var response = await categoryApplication.DeleteCategory(id);
            return Ok(response);
        }
        [HttpGet("get-categpries")]
        public async Task<IActionResult> GetCategories()
        {
            var response = await categoryApplication.ListCategoryCombobox();
            return Ok(response);
        }

    }
}
