using AuhtServer.Shared.Results;
using System.Linq.Expressions;

namespace AuthServer.Domain.Services;

public interface IServiceManager<TEntity, TDto> where TEntity : class where TDto : class
{
    Task<Result<IEnumerable<TDto>>> GetListAsync();
    Task<Result<TDto>> GetByIdAsync(string id);
    Task<Result<IEnumerable<TDto>>> FilteredAsync(Expression<Func<TEntity, bool>> expression);
    Task<Result<TDto>> AddAsync(TEntity entity);
    Task<Result> UpdateAsync(TEntity entity);
    Task<Result> DeleteAsync(TEntity entity);
}
