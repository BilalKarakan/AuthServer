using AuhtServer.Shared.Configurations;
using AuhtServer.Shared.Helper;
using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;
using AuthServer.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json;

namespace AuthServer.Business.Services;

public class TokenService : ITokenService 
{
    private readonly UserManager<AppUser> _userManager;
    private readonly AppSettings _options;
    private readonly VaultHelper _vaultHelper;

    public TokenService(UserManager<AppUser> userManager, IOptions<AppSettings> options, VaultHelper vaultHelper)
    {
        _userManager = userManager;
        _options = options.Value;
        _vaultHelper = vaultHelper;
    }

    /// <summary>
    /// This method generates a cryptographically secure random 48-byte string. The generated value is used for both refresh token and token ID creation. 
    /// </summary>
    /// <returns>The generated refresh token.</returns>
    private string GenerateRefreshToken()
    {
        byte[] bytes = new byte[48];
        RandomNumberGenerator.Fill(bytes);
        return Convert.ToBase64String(bytes);
    }

    private List<Claim> GenerateClaimsForUser(AppUser user, List<string> audiences)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id?? string.Empty),
            new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
            new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
            new Claim(JwtRegisteredClaimNames.Jti, GenerateRefreshToken())
        };

        claims.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));
        return claims;
    }

    private List<Claim> GenerateClaimsForClient(Client client)
    {
        List<Claim> claims = new List<Claim>();
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, GenerateRefreshToken()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, client.ClientId));
        claims.AddRange(client.Audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x.Audience)));
        return claims;
    }

    public async Task<ClientTokenDto> GenerateClientTokenAsync(Client client)
    {
        var data = await _vaultHelper.GetVaultKeys();
        var jsonData = (JsonElement)data.Data.Data["JWTOption"];

        var accessTokenExpire = DateTime.Now.AddMinutes(jsonData.GetProperty(AppSettings.AccessTokenExpire).GetInt32());
        var refreshTokenExpire = DateTime.Now.AddMinutes(jsonData.GetProperty(AppSettings.RefreshTokenExpire).GetInt32());
        var securityKey = SignatureHelper.CreateSignature(jsonData.GetProperty(AppSettings.SecurityKey).ToString());

        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        System.IdentityModel.Tokens.Jwt.JwtSecurityToken jwtSecurityToken = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken
            (
                issuer: jsonData.GetProperty(AppSettings.Issuer).ToString(),
                expires: accessTokenExpire,
                notBefore: DateTime.Now,
                claims: GenerateClaimsForClient(client),
                signingCredentials: signingCredentials
            );

        var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
        var token = handler.WriteToken(jwtSecurityToken);
        var tokenDto = new ClientTokenDto
        {
            AccessToken = token,
            AccessTokenExpire = accessTokenExpire,
        };
        return tokenDto;
    }

    public async Task<TokenDto> GenerateTokenAsync(AppUser user)
    {
        var data = await _vaultHelper.GetVaultKeys();
        var jsonData = (JsonElement)data.Data.Data["JWTOption"];

        var accessTokenExpire = DateTime.UtcNow.AddMinutes(jsonData.GetProperty(AppSettings.AccessTokenExpire).GetInt32());
        var refreshTokenExpire = DateTime.UtcNow.AddMinutes(jsonData.GetProperty(AppSettings.RefreshTokenExpire).GetInt32());
        var securityKey = SignatureHelper.CreateSignature(jsonData.GetProperty(AppSettings.SecurityKey).ToString());

        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        System.IdentityModel.Tokens.Jwt.JwtSecurityToken jwtSecurityToken = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken
            (
                issuer: jsonData.GetProperty(AppSettings.Issuer).ToString(),
                expires: accessTokenExpire,
                notBefore: DateTime.UtcNow,
                claims: GenerateClaimsForUser(user, jsonData.GetProperty(AppSettings.Audience).EnumerateArray().Select(x => x.ToString()).ToList()),
                signingCredentials: signingCredentials
            );

        var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
        var token = handler.WriteToken(jwtSecurityToken);
        var tokenDto = new TokenDto
        {
            AccessToken = token,
            RefreshToken = GenerateRefreshToken(),
            AccessTokenExpire = accessTokenExpire,
            RefreshTokenExpire = refreshTokenExpire
        };
        return tokenDto;
    }
}
