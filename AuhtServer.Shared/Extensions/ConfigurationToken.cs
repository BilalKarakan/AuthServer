using AuhtServer.Shared.Configurations;
using AuhtServer.Shared.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AuhtServer.Shared.Extensions;

public static class ConfigurationToken
{
    public async static Task AddConfigurationToken(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<VaultHelper>();
        VaultHelper vaultHelper = new VaultHelper(Options.Create(configuration.GetSection(AppSettings.VaultKeys).Get<AppSettings>()!));
        var data = await vaultHelper.GetVaultKeys();
        var jwtSettings = (JsonElement)data.Data.Data[AppSettings.JWTOption];
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
    }
}
