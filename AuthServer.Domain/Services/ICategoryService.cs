using AuhtServer.Shared.Results;
using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;
using AuthServer.Domain.Repositories;

namespace AuthServer.Domain.Services;

public interface ICategoryService
{
    Task<Result> UpdateAsync(UpdateCategoryDto model);
    Task<Result<IEnumerable<CategoryDto>>> GetListAsync();
    Task<Result<CategoryDto>> GetByIdAsync(string id);
    Task<Result> DeleteAsync(string id);
    Task<Result<CreateCategoryDto>> AddAsync(CreateCategoryDto model);
    Task<Result<CategoryDto>> GetCategoryWithProductsAsync(string id);
}
