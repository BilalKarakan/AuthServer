using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;
using AuthServer.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.API.Controllers;

[Authorize]
public class CategoryController(IServiceManager<Category, CategoryDto> _serviceManager, ICategoryService _categoryService) : BaseController
{
    [HttpGet("[action]")] public async Task<IActionResult> GetListAsync() => CreateInstance(await _serviceManager.GetListAsync());
    [HttpGet("{id}"), Route("[action]")] public async Task<IActionResult> GetByIdAsync(string id) => CreateInstance(await _serviceManager.GetByIdAsync(id));
    [HttpPost("[action]")] public async Task<IActionResult> AddAsync([FromBody] CategoryDto category) => CreateInstance(await _serviceManager.AddAsync(category));
    [HttpPut("[action]")] public async Task<IActionResult> UpdateAsync([FromBody] CategoryDto category) => CreateInstance(await _serviceManager.UpdateAsync(category));
    [HttpDelete("[action]")] public async Task<IActionResult> DeleteAsync([FromBody] CategoryDto category) => CreateInstance(await _serviceManager.DeleteAsync(category));
    [HttpGet("{id}"), Route("[action]")] public async Task<IActionResult> GetCategoryWithProductsAsync(string id) => CreateInstance(await _categoryService.GetCategoryWithProductsAsync(id));
}
