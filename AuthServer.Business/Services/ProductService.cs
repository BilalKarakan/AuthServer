using AuhtServer.Shared.Results;
using AuthServer.DataAccess.Repositories;
using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;
using AuthServer.Domain.Repositories;
using AuthServer.Domain.Services;
using System.Net;
using VaultSharp.V1.SecretsEngines.Identity;

namespace AuthServer.Business.Services;

public class ProductService(IProductRepository _repository, IUnitOfWork _unitOfWork) : IProductService
{
    public async Task<Result<CreateProductDto>> AddAsync(CreateProductDto model)
    {
        var entity = ObjectMapper.Mapper.Map<Product>(model);
        await _repository.AddAsync(entity);
        await _unitOfWork.SaveAsync();
        return Result<CreateProductDto>.Success(model, HttpStatusCode.Created);
    }

    public async Task<Result> DeleteAsync(string id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            return Result.Fail($"{nameof(Product)} not found", HttpStatusCode.NotFound);
        _repository.Delete(entity);
        await _unitOfWork.SaveAsync();
        return Result.Success(HttpStatusCode.NoContent);
    }

    public async Task<Result<ProductDto>> GetByIdAsync(string id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            return Result<ProductDto>.Fail($"{nameof(Product)} not found", HttpStatusCode.NotFound);
        var dto = ObjectMapper.Mapper.Map<ProductDto>(entity);
        return Result<ProductDto>.Success(dto);
    }

    public async Task<Result<IEnumerable<ProductDto>>> GetListAsync()
    {
        var entities = _repository.GetList().ToList();
        var dtos = ObjectMapper.Mapper.Map<IEnumerable<ProductDto>>(entities);
        return Result<IEnumerable<ProductDto>>.Success(dtos);
    }

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

    public async Task<Result> UpdateAsync(UpdateProductDto model)
    {
        var existingEntity = await _repository.GetByIdAsync(model.Id);

        if (existingEntity is null)
            return Result.Fail($"{nameof(Product)} not found", HttpStatusCode.NotFound);

        ObjectMapper.Mapper.Map(model, existingEntity);

        await _unitOfWork.SaveAsync();

        return Result.Success(HttpStatusCode.NoContent);
    }
}
