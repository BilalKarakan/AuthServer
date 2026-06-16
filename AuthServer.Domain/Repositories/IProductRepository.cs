using AuthServer.Domain.Entities;

namespace AuthServer.Domain.Repositories;

public interface IProductRepository
{
    Task<Product> GetProductWithCategoryAsync(string id);
    Task<List<Product>> GetProductsWithCategoryAsync();
}
