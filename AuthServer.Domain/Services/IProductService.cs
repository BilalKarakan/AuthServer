using AuhtServer.Shared.Results;
using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;

namespace AuthServer.Domain.Services;

public interface IProductService
{
    Task<Result<ProductDto>> GetProductWithCategoryAsync(string id);
    Task<Result<List<ProductDto>>> GetProductsWithCategoryAsync();
}
