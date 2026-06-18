using AuthServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.DataAccess;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<AppUser, IdentityRole, string>(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<ClientAudience> ClientAudiences => Set<ClientAudience>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ChangeTracker.Entries<BaseEntity>().ToList().ForEach(entity =>
        {
            _ = entity.State switch
            {
                EntityState.Added => entity.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => entity.Entity.UpdatedDate = DateTime.UtcNow,
                _ => null
            };
        });

        return await base.SaveChangesAsync(cancellationToken);
    }
}
