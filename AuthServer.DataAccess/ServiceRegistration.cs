using AuhtServer.Shared.Configurations;
using AuhtServer.Shared.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace AuthServer.DataAccess;

public static class ServiceRegistration
{
    public static async Task<IServiceCollection> AddDataAccessRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<VaultHelper>();
        VaultHelper vaultHelper = new VaultHelper(Options.Create(configuration.GetSection("VaultKeys").Get<AppSettings>()));
        var data = await vaultHelper.GetVaultKeys();
        var connectionString = (JsonElement)data.Data.Data["ConnectionStrings"];
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString.GetProperty("PostgreConnection").GetString(), b => b.MigrationsAssembly("AuthServer.DataAccess"));
        });
        return services;
    }
}
