using AuthServer.Domain.DTOs;
using AuthServer.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController(IAuthService _authService) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateTokenAsync(SignInDto signInDto) => CreateInstance(await _authService.CreateTokenAsync(signInDto));

    [HttpPost]
    public async Task<IActionResult> CreateClientTokenAsync(ClientSignInDto clientSignInDto) => CreateInstance(await _authService.CreateClientTokenAsync(clientSignInDto));

    [HttpPost]
    public async Task<IActionResult> CreateTokenByRefreshTokenAsync(RefreshTokenDto refreshTokenDto) => CreateInstance(await _authService.CreateTokenByRefreshTokenAsync(refreshTokenDto.Token));

    [HttpPost]
    public async Task<IActionResult> CancelRefreshTokenAsync(RefreshTokenDto refreshTokenDto) => CreateInstance(await _authService.CancelRefreshTokenAsync(refreshTokenDto.Token));
}
