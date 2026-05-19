using AuthServer.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace AuthServer.DataAccess.Repositories;

public class GenericRepository<T>(ApplicationDbContext _context) : IGenericRepository<T> where T : class
{
    public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

    public void Delete(T entity) => _context.Set<T>().Remove(entity);

    public IQueryable<T> FilteredAsync(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression);

    public async Task<T?> GetByIdAsync(string id) => await _context.Set<T>().FindAsync(id);

    public IQueryable<T> GetList() => _context.Set<T>().AsNoTracking();

    public void Update(T entity) => _context.Set<T>().Update(entity);
}
