using AuthServer.Business.Services;
using AuthServer.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer.Business;

public static class ServiceRegistration
{
    public static IServiceCollection AddServicesRegistration(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped(typeof(IServiceManager<,>), typeof(ServiceManager<,>));
        return services;
    }
}
