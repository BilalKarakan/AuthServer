namespace AuthServer.Domain.Services;

public interface IUnitOfWork
{
    void Save();
    Task SaveAsync();
}
