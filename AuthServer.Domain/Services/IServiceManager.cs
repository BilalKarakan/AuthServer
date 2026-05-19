using AuhtServer.Shared.Results;
using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;
using System.Linq.Expressions;

namespace AuthServer.Domain.Services;

public interface IServiceManager<TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDto
{
    Task<Result<IEnumerable<TDto>>> GetListAsync();
    Task<Result<TDto>> GetByIdAsync(string id);
    Task<Result<IQueryable<TDto>>> FilteredAsync(Expression<Func<TDto, bool>> expression);
    Task<Result<TDto>> AddAsync(TDto model);
    Task<Result> UpdateAsync(TDto model);
    Task<Result> DeleteAsync(TDto model);
}
