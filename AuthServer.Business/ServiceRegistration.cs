using AuthServer.Business.Services;
using AuthServer.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer.Business;

public static class ServiceRegistration
{
    public static IServiceCollection AddServicesRegistration(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        });

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        return services;
    }
}
