using AuthServer.Domain.Entities;

namespace AuthServer.Domain.Repositories;
public interface ICategoryRepository
{
    Task<Category> GetCategoryWithProductsAsync(string id);
}
