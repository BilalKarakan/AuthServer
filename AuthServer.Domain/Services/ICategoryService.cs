using AuhtServer.Shared.Results;
using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;

namespace AuthServer.Domain.Services;

public interface ICategoryService
{
    Task<Result<CategoryDto>> GetCategoryWithProductsAsync(string id);
}
