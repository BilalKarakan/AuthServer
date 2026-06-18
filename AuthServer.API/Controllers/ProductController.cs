using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;
using AuthServer.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductService _productService) : BaseController
{
    [HttpGet("[action]")] public async Task<IActionResult> GetListAsync() => CreateInstance(await _productService.GetListAsync());
    [HttpGet("[action]/{id}")] public async Task<IActionResult> GetByIdAsync([FromRoute] string id) => CreateInstance(await _productService.GetByIdAsync(id));
    [HttpPost("[action]")] public async Task<IActionResult> AddAsync([FromBody] CreateProductDto product) => CreateInstance(await _productService.AddAsync(product));
    [HttpPut("[action]")] public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductDto product) => CreateInstance(await _productService.UpdateAsync(product));
    [HttpDelete("[action]/{id}")] public async Task<IActionResult> DeleteAsync([FromRoute] string id) => CreateInstance(await _productService.DeleteAsync(id));
    [HttpGet("[action]")] public async Task<IActionResult> GetProductsWithCategoryAsync() => CreateInstance(await _productService.GetProductsWithCategoryAsync());
    [HttpGet("[action]/{id}")] public async Task<IActionResult> GetProductWithCategoryAsync([FromRoute] string id) => CreateInstance(await _productService.GetProductWithCategoryAsync(id));
}
