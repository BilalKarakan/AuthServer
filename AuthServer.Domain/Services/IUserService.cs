using AuhtServer.Shared.Results;
using AuthServer.Domain.DTOs;

namespace AuthServer.Domain.Services;

public interface IUserService
{
    Task<Result<AppUserDto>> CreateUserAsync(CreateUserDto userDto);
    Task<Result<AppUserDto>> GetUserByNameAsync(string userName);
}
