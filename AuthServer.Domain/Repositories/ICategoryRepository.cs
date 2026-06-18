using AuthServer.Domain.Entities;

namespace AuthServer.Domain.Repositories;
public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<Category> GetCategoryWithProductsAsync(string id);
}
