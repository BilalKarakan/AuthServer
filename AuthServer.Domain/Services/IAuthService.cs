using AuhtServer.Shared.Results;
using AuthServer.Domain.DTOs;

namespace AuthServer.Domain.Services;

public interface IAuthService
{
    Task<Result<TokenDto>> CreateTokenAsync(SignInDto model);
    Task<Result<ClientTokenDto>> CreateClientTokenAsync(ClientSignInDto model);
    Task<Result<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken);
    Task<Result> CancelRefreshTokenAsync(string refreshToken);
}
