using AuhtServer.Shared.Results;
using AuthServer.Domain.DTOs;
using AuthServer.Domain.Entities;
using AuthServer.Domain.Services;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace AuthServer.Business.Services;

public class UserService(UserManager<AppUser> _userManager) : IUserService
{
    public async Task<Result<AppUserDto>> CreateUserAsync(CreateUserDto userDto)
    {
        var user = new AppUser() { Email = userDto.Email, UserName = userDto.UserName};
        var identityResult = await _userManager.CreateAsync(user, userDto.Password);
        if (!identityResult.Succeeded)
        {
            var identityErrors = identityResult.Errors.Select(e => e.Description).ToList();
            return Result<AppUserDto>.Fail(identityErrors, HttpStatusCode.BadRequest);
        }
        
        return Result<AppUserDto>.Success(ObjectMapper.Mapper.Map<AppUserDto>(user), HttpStatusCode.Created);
    }

    public async Task<Result<AppUserDto>> GetUserByNameAsync(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        if (user is null)
            return Result<AppUserDto>.Fail($"User with name {userName} not found", HttpStatusCode.NotFound);

        return Result<AppUserDto>.Success(ObjectMapper.Mapper.Map<AppUserDto>(user), HttpStatusCode.OK);
    }
}
