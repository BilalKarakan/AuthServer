using AuhtServer.Shared.Results;
using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;
using AuthServer.Domain.Repositories;
using AuthServer.Domain.Services;
using System.Linq.Expressions;
using System.Net;

namespace AuthServer.Business.Services;

public class ServiceManager<TEntity, TDto>(IGenericRepository<TEntity> _repository, IUnitOfWork _unitOfWork) : IServiceManager<TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDto
{
    public async Task<Result<TDto>> AddAsync(TDto model)
    {
        var entity = ObjectMapper.Mapper.Map<TEntity>(model);
        await _repository.AddAsync(entity);
        await _unitOfWork.SaveAsync();
        return Result<TDto>.Success(model, HttpStatusCode.Created); 
    }

    public async Task<Result> DeleteAsync(TDto model)
    {
        var entity = ObjectMapper.Mapper.Map<TEntity>(model);
        entity = await _repository.GetByIdAsync(entity.Id);
        if (entity is null)
            return Result.Fail($"{nameof(TEntity)} not found", HttpStatusCode.NotFound);
        _repository.Delete(entity);
        await _unitOfWork.SaveAsync();
        return Result.Success(HttpStatusCode.NoContent);
    }

    public async Task<Result<IQueryable<TDto>>> FilteredAsync(Expression<Func<TDto, bool>> expression)
    {
        var entities = ObjectMapper.Mapper.Map<IQueryable<TEntity>>(_repository.FilteredAsync(ObjectMapper.Mapper.Map<Expression<Func<TEntity, bool>>>(expression)));
        var dtos = ObjectMapper.Mapper.Map<IQueryable<TDto>>(entities);
        return Result<IQueryable<TDto>>.Success(dtos);
    }

    public async Task<Result<TDto>> GetByIdAsync(string id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null)
            return Result<TDto>.Fail($"{nameof(TEntity)} not found", HttpStatusCode.NotFound);
        var dto = ObjectMapper.Mapper.Map<TDto>(entity);
        return Result<TDto>.Success(dto);
    }

    public async Task<Result<IEnumerable<TDto>>> GetListAsync()
    {
        var entities = _repository.GetList().ToList();
        var dtos = ObjectMapper.Mapper.Map<IEnumerable<TDto>>(entities);
        return Result<IEnumerable<TDto>>.Success(dtos);
    }

    public async Task<Result> UpdateAsync(TDto model)
    {
        var entity = ObjectMapper.Mapper.Map<TEntity>(model);
        entity = await _repository.GetByIdAsync(entity.Id);
        if (entity is null)
            return Result.Fail($"{nameof(TEntity)} not found", HttpStatusCode.NotFound);
        _repository.Update(entity);
        await _unitOfWork.SaveAsync();
        return Result.Success(HttpStatusCode.NoContent);
    }
}
