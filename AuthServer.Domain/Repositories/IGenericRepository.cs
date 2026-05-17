using System.Linq.Expressions;

namespace AuthServer.Domain.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<IQueryable<T>> GetListAsync();
    Task<T> GetByIdAsync(string id);
    Task<IQueryable<T>> FilteredAsync(Expression<Func<T, bool>> expression);
    Task AddAsync(T entity);
    void Delete(T entity);
    void Update(T entity);
}
