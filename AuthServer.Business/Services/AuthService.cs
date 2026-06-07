using AuhtServer.Shared.Configurations;
using AuhtServer.Shared.Helper;
using AuhtServer.Shared.Results;
using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;
using AuthServer.Domain.Repositories;
using AuthServer.Domain.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;
using VaultSharp.V1.Commons;

namespace AuthServer.Business.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<AppUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<RefreshToken> _refreshToken;
    private readonly IGenericRepository<Client> _client;

    public AuthService(ITokenService tokenService, UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IGenericRepository<RefreshToken> refreshToken, IGenericRepository<Client> client)
    {
        _tokenService = tokenService;
        _userManager = userManager;
        _unitOfWork = unitOfWork;
        _refreshToken = refreshToken;
        _client = client;
    }
    public async Task<Result> CancelRefreshTokenAsync(string refreshToken)
    {
        var existRefreshToken = await _refreshToken.FilteredAsync(x => x.Token == refreshToken).SingleOrDefaultAsync();
        if (existRefreshToken == null)
            Result.Fail("Refresh token not found!", HttpStatusCode.BadRequest);

        _refreshToken.Delete(existRefreshToken);
        await _unitOfWork.SaveAsync();
        return Result.Success(HttpStatusCode.OK);
    }

    public async Task<Result<ClientTokenDto>> CreateClientTokenAsync(ClientSignInDto model)
    {
        var client = await _client.FilteredAsync(x => x.ClientId == model.ClientId && x.SecretKey == model.SecretKey).SingleOrDefaultAsync();

        if (client == null)
            return Result<ClientTokenDto>.Fail("ClientId or SecretKey is wrong!", HttpStatusCode.BadRequest);

        var token = await _tokenService.GenerateClientTokenAsync(client);
        return Result<ClientTokenDto>.Success(token, HttpStatusCode.OK);
    }

    public async Task<Result<TokenDto>> CreateTokenAsync(SignInDto model)
    {
        if (model == null) 
            throw new ArgumentNullException(nameof(model));

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
            return Result<TokenDto>.Fail("Email or password is wrong!", HttpStatusCode.BadRequest);

        bool isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);

        if (!isPasswordValid)
            return Result<TokenDto>.Fail("Email or password is wrong!", HttpStatusCode.BadRequest);

        var token = await _tokenService.GenerateTokenAsync(user);
        var refreshToken = await _refreshToken.FilteredAsync(x => x.UserId == user.Id).SingleOrDefaultAsync();

        if (refreshToken == null) 
            await _refreshToken.AddAsync(new RefreshToken { UserId = user.Id, Token = token.RefreshToken, CreatedAt = DateTime.UtcNow, ExpiresAt = token.RefreshTokenExpire, IsRevoked = false, RevokedAt = null });
        else
        {
            refreshToken.Token = token.RefreshToken;
            refreshToken.ExpiresAt = token.RefreshTokenExpire;
            refreshToken.CreatedAt = DateTime.UtcNow;
            refreshToken.IsRevoked = false;
            refreshToken.RevokedAt = null;
        }

        await _unitOfWork.SaveAsync();
        return Result<TokenDto>.Success(token, HttpStatusCode.OK);

    }

    public async Task<Result<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken)
    {
        var existRefreshToken = await _refreshToken.FilteredAsync(x => x.Token == refreshToken).SingleOrDefaultAsync();

        if (existRefreshToken == null || existRefreshToken.IsRevoked || existRefreshToken.ExpiresAt < DateTime.Now)
            return Result<TokenDto>.Fail("Invalid refresh token!", HttpStatusCode.BadRequest);

        var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);
        if (user == null)
            return Result<TokenDto>.Fail("User not found!", HttpStatusCode.BadRequest);

        var token = await _tokenService.GenerateTokenAsync(user);
        existRefreshToken.Token = token.RefreshToken;
        existRefreshToken.ExpiresAt = token.RefreshTokenExpire;
        existRefreshToken.CreatedAt = DateTime.UtcNow;
        existRefreshToken.IsRevoked = false;
        existRefreshToken.RevokedAt = null;

        await _unitOfWork.SaveAsync();
        return Result<TokenDto>.Success(token, HttpStatusCode.OK);
    }
}
