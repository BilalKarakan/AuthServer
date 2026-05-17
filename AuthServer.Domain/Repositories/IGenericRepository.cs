using System.Linq.Expressions;

namespace AuthServer.Domain.Repositories;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> GetList();
    Task<T> GetByIdAsync(string id);
    IQueryable<T> FilteredAsync(Expression<Func<T, bool>> expression);
    Task AddAsync(T entity);
    void Delete(T entity);
    void Update(T entity);
}
