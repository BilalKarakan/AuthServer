using AuhtServer.Shared.Configurations;
using AuhtServer.Shared.Helper;
using AuthServer.DataAccess.Repositories;
using AuthServer.Domain.Entities;
using AuthServer.Domain.Repositories;
using AuthServer.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Sinks.PostgreSQL;
using System.Text.Json;

namespace AuthServer.DataAccess;

public static class ServiceRegistration
{
    public async static Task<IServiceCollection> AddDataAccessRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<VaultHelper>();
        VaultHelper vaultHelper = new VaultHelper(Options.Create(configuration.GetSection(AppSettings.VaultKeys).Get<AppSettings>()!));
        var data = await vaultHelper.GetVaultKeys();
        var connectionString = (JsonElement)data.Data.Data[AppSettings.ConnectionStrings];
        var jwtSettings = (JsonElement)data.Data.Data[AppSettings.JWTOption];
        var postgresConnection = connectionString.GetProperty(AppSettings.PostgreConnection).GetString();

        if (string.IsNullOrWhiteSpace(postgresConnection))
            throw new Exception("PostgreConnection Vault üzerinden okunamadı.");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(postgresConnection, b => b.MigrationsAssembly("AuthServer.DataAccess"));
        });


        services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
        }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .WriteTo.PostgreSQL
            (
                connectionString: postgresConnection,
                tableName: "Logs",
                needAutoCreateTable: true
        ).CreateLogger();

        services.AddSerilog();

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();


        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
        {
            opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.GetProperty(AppSettings.Issuer).GetString(),
                ValidAudience = jwtSettings.GetProperty(AppSettings.Audience).EnumerateArray().First().GetString(),
                IssuerSigningKey = SignatureHelper.CreateSignature(jwtSettings.GetProperty(AppSettings.SecurityKey).GetString()!),
                ClockSkew = TimeSpan.Zero
            };
        });


        return services;
    }
}
