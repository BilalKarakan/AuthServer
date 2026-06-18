using AuhtServer.Shared.Results;
using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;
using AuthServer.Domain.Repositories;
using AuthServer.Domain.Services;
using System.Linq.Expressions;
using System.Net;

namespace AuthServer.Business.Services;

public class CategoryService(ICategoryRepository _repository, IUnitOfWork _unitOfWork) : ICategoryService
{
    public async Task<Result<CreateCategoryDto>> AddAsync(CreateCategoryDto model)
    {
        var entity = ObjectMapper.Mapper.Map<Category>(model);
        await _repository.AddAsync(entity);
        await _unitOfWork.SaveAsync();
        return Result<CreateCategoryDto>.Success(ObjectMapper.Mapper.Map<CreateCategoryDto>(entity));   
    }
    public async Task<Result> DeleteAsync(string id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            return Result.Fail("Category not found", HttpStatusCode.NotFound);

        _repository.Delete(entity);
        await _unitOfWork.SaveAsync();
        return Result.Success(HttpStatusCode.NoContent);
    }
    public async Task<Result<CategoryDto>> GetByIdAsync(string id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            return Result<CategoryDto>.Fail($"{nameof(Category)} not found", HttpStatusCode.NotFound);

        return Result<CategoryDto>.Success(ObjectMapper.Mapper.Map<CategoryDto>(entity), HttpStatusCode.OK);
    }

    public async Task<Result<CategoryDto>> GetCategoryWithProductsAsync(string id)
    {
        var category = await _repository.GetCategoryWithProductsAsync(id);
        if (category is null)
            return Result<CategoryDto>.Fail("Category not found", HttpStatusCode.NotFound);

        return Result<CategoryDto>.Success(ObjectMapper.Mapper.Map<CategoryDto>(category), HttpStatusCode.OK);
    }

    public async Task<Result<IEnumerable<CategoryDto>>> GetListAsync()
    {
        var entities = _repository.GetList();
        var dtos = ObjectMapper.Mapper.Map<IEnumerable<CategoryDto>>(entities);
        return Result<IEnumerable<CategoryDto>>.Success(dtos, HttpStatusCode.OK);
    }

    public async Task<Result> UpdateAsync(UpdateCategoryDto model)
    {
        var existingEntity = await _repository.GetByIdAsync(model.Id);

        if (existingEntity is null)
            return Result.Fail($"{nameof(Category)} not found", HttpStatusCode.NotFound);

        ObjectMapper.Mapper.Map(model, existingEntity);

        await _unitOfWork.SaveAsync();

        return Result.Success(HttpStatusCode.NoContent);
    }
}
