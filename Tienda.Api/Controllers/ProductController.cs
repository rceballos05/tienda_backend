using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tienda.Application.Dtos.Requests;
using Tienda.Application.Interfaces;
using Tienda.Infrastructure.Commons.Bases.Requests;

namespace Tienda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication productApplication;
        public ProductController(IProductApplication _productApplication)
        {
            productApplication = _productApplication;
        }
        [HttpPost("list-products")]
        public async Task<IActionResult> ListProducts([FromBody] BaseFilterRequest filter)
        {
            var response = await productApplication.ListProduct(filter);
            return Ok(response);
        }
        [HttpGet("list-product/{id:int}")]
        public async Task<IActionResult> ProductByID(int id)
        {
            var response = await productApplication.ProductById(id);
            return Ok(response);
        }
        [HttpPost("register-product")]
        public async Task<IActionResult> RegisterProduct([FromBody] ProductDtoRequest productDto)
        {
            var response = await productApplication.RegisterProduct(productDto);
            return Ok(response);
        }
        [HttpPut("edit-product/{id:int}")]
        public async Task<IActionResult> EditProduct(int id, [FromBody] ProductDtoRequest productDto)
        {
            var response = await productApplication.EditProduct(id, productDto);
            return Ok(response);
        }
        [HttpDelete("delete-product/{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await productApplication.DeleteProduct(id);
            return Ok(response);
        }
    }
}
