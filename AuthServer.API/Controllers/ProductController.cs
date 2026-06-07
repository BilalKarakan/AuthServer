using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;
using AuthServer.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductController(IServiceManager<Product, ProductDto> _serviceManager) : BaseController
{
    [HttpGet] public async Task<IActionResult> GetListAsync() => CreateInstance(await _serviceManager.GetListAsync());
    [HttpGet("{id}")] public async Task<IActionResult> GetByIdAsync([FromRoute] string id) => CreateInstance(await _serviceManager.GetByIdAsync(id));
    [HttpPost] public async Task<IActionResult> AddAsync([FromBody] ProductDto product) => CreateInstance(await _serviceManager.AddAsync(product));
    [HttpPut] public async Task<IActionResult> UpdateAsync([FromBody] ProductDto product) => CreateInstance(await _serviceManager.UpdateAsync(product));
    [HttpDelete] public async Task<IActionResult> DeleteAsync([FromBody] ProductDto product) => CreateInstance(await _serviceManager.DeleteAsync(product));
}
