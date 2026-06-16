using AuhtServer.Shared.Results;
using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;
using AuthServer.Domain.Repositories;
using AuthServer.Domain.Services;
using System.Net;

namespace AuthServer.Business.Services;

public class ProductService(IProductRepository _repository) : IProductService
{
    public async Task<Result<List<ProductDto>>> GetProductsWithCategoryAsync()
    {
        var products = await _repository.GetProductsWithCategoryAsync();
        if (products is null)
            return Result<List<ProductDto>>.Fail("Products not found", HttpStatusCode.NotFound);

        return Result<List<ProductDto>>.Success(ObjectMapper.Mapper.Map<List<ProductDto>>(products), HttpStatusCode.OK);
    }

    public async Task<Result<ProductDto>> GetProductWithCategoryAsync(string id)
    {
        var product = await _repository.GetProductWithCategoryAsync(id);
        if (product is null)
            return Result<ProductDto>.Fail("Product not found", HttpStatusCode.NotFound);

        return Result<ProductDto>.Success(ObjectMapper.Mapper.Map<ProductDto>(product), HttpStatusCode.OK);
    }
}
