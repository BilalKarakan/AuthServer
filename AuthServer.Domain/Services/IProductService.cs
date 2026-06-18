using AuhtServer.Shared.Results;
using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;
using AuthServer.Domain.Repositories;

namespace AuthServer.Domain.Services;

public interface IProductService
{
    Task<Result> UpdateAsync(UpdateProductDto model);
    Task<Result<IEnumerable<ProductDto>>> GetListAsync();
    Task<Result<ProductDto>> GetByIdAsync(string id);
    Task<Result> DeleteAsync(string id);
    Task<Result<CreateProductDto>> AddAsync(CreateProductDto model);
    Task<Result<ProductDto>> GetProductWithCategoryAsync(string id);
    Task<Result<List<ProductDto>>> GetProductsWithCategoryAsync();
}
