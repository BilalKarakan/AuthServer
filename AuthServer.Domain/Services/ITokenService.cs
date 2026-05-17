using AuthServer.Domain.Entities;
using AuthServer.Domain.DTOs;

namespace AuthServer.Domain.Services;

public interface ITokenService
{
    Task<TokenDto> GenerateTokenAsync(AppUser user);
    Task<ClientTokenDto> GenerateClientTokenAsync(ClientDto client);
}
