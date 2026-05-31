using AuthServer.Domain.Entities;
using AuthServer.Domain.DTOs;
using System.Security.Claims;

namespace AuthServer.Domain.Services;

public interface ITokenService
{
    Task<TokenDto> GenerateTokenAsync(AppUser user);
    Task<ClientTokenDto> GenerateClientTokenAsync(Client client);
}
