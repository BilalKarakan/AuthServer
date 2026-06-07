using AuthServer.Domain.DTOs;
using AuthServer.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService _userService) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateUserAsync(CreateUserDto createUserDto) => CreateInstance(await _userService.CreateUserAsync(createUserDto));

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetUserByNameAsync() => CreateInstance(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
}
