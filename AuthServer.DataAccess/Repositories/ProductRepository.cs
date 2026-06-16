using AuthServer.Domain.Entities;
using AuthServer.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.DataAccess.Repositories;

public class ProductRepository(ApplicationDbContext _context) : GenericRepository<Product>(_context), IProductRepository
{
    public async Task<Product> GetProductWithCategoryAsync(string id) => await _context.Products.Where(x => x.Id == id).Include(x => x.Category).AsNoTracking().FirstOrDefaultAsync();
    public async Task<List<Product>> GetProductsWithCategoryAsync() => await _context.Products.Include(x => x.Category).AsNoTracking().ToListAsync();
}
