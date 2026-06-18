using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;
using AuthServer.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.API.Controllers;

[Authorize]
public class CategoryController(ICategoryService _categoryService) : BaseController
{
    [HttpGet("[action]")] public async Task<IActionResult> GetListAsync() => CreateInstance(await _categoryService.GetListAsync());
    [HttpGet("[action]/{id}")] public async Task<IActionResult> GetByIdAsync(string id) => CreateInstance(await _categoryService.GetByIdAsync(id));
    [HttpPost("[action]")] public async Task<IActionResult> AddAsync([FromBody] CreateCategoryDto category) => CreateInstance(await _categoryService.AddAsync(category));
    [HttpPut("[action]")] public async Task<IActionResult> UpdateAsync([FromBody] UpdateCategoryDto category) => CreateInstance(await _categoryService.UpdateAsync(category));
    [HttpDelete("[action]/{id}")] public async Task<IActionResult> DeleteAsync([FromRoute] string id) => CreateInstance(await _categoryService.DeleteAsync(id));
    [HttpGet("[action]/{id}")] public async Task<IActionResult> GetCategoryWithProductsAsync(string id) => CreateInstance(await _categoryService.GetCategoryWithProductsAsync(id));
}
