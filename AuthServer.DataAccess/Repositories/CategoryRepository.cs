using AuthServer.Domain.Entities;
using AuthServer.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.DataAccess.Repositories;

public class CategoryRepository(ApplicationDbContext _context) : GenericRepository<Category>(_context), ICategoryRepository
{
    public async Task<Category> GetCategoryWithProductsAsync(string id) => await _context.Categories.Include(x => x.Products).AsNoTracking().FirstOrDefaultAsync();
}
