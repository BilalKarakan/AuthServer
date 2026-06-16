using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;
using AuthServer.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductController(IServiceManager<Product, ProductDto> _serviceManager, IProductService _productService) : BaseController
{
    [HttpGet("[action]")] public async Task<IActionResult> GetListAsync() => CreateInstance(await _serviceManager.GetListAsync());
    [HttpGet("[action]/{id}")] public async Task<IActionResult> GetByIdAsync([FromRoute] string id) => CreateInstance(await _serviceManager.GetByIdAsync(id));
    [HttpPost("[action]")] public async Task<IActionResult> AddAsync([FromBody] ProductDto product) => CreateInstance(await _serviceManager.AddAsync(product));
    [HttpPut("[action]")] public async Task<IActionResult> UpdateAsync([FromBody] ProductDto product) => CreateInstance(await _serviceManager.UpdateAsync(product));
    [HttpDelete("[action]")] public async Task<IActionResult> DeleteAsync([FromBody] ProductDto product) => CreateInstance(await _serviceManager.DeleteAsync(product));
    [HttpGet("[action]")] public async Task<IActionResult> GetProductsWithCategoryAsync() => CreateInstance(await _productService.GetProductsWithCategoryAsync());
    [HttpGet("[action]/{id}")] public async Task<IActionResult> GetProductWithCategoryAsync([FromRoute] string id) => CreateInstance(await _productService.GetProductWithCategoryAsync(id));
}
