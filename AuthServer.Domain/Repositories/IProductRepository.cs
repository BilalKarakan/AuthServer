using AuthServer.Domain.Entities;

namespace AuthServer.Domain.Repositories;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product> GetProductWithCategoryAsync(string id);
    Task<List<Product>> GetProductsWithCategoryAsync();
}
