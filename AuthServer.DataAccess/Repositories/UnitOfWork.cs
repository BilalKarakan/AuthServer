using AuthServer.Domain.Services;

namespace AuthServer.DataAccess.Repositories;

public class UnitOfWork(ApplicationDbContext _context) : IUnitOfWork
{
    public void Save() => _context.SaveChanges();

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}
