using AuhtServer.Shared.Results;
using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;
using AuthServer.Domain.Repositories;
using AuthServer.Domain.Services;
using System.Net;

namespace AuthServer.Business.Services;

public class CategoryService(ICategoryRepository _repository) : ICategoryService
{
    public async Task<Result<CategoryDto>> GetCategoryWithProductsAsync(string id)
    {
        var category = await _repository.GetCategoryWithProductsAsync(id);
        if (category is null)
            return Result<CategoryDto>.Fail("Category not found", HttpStatusCode.NotFound);

        return Result<CategoryDto>.Success(ObjectMapper.Mapper.Map<CategoryDto>(category), HttpStatusCode.OK);
    }
}
