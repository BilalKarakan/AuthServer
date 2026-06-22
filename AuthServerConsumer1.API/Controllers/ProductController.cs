using AuthServerConsumer1.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace AuthServerConsumer1.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductController(IHttpClientFactory _httpClientFactory) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var client = _httpClientFactory.CreateClient("AuthServer");

        // Vault'dan çekilecek
        var tokenRequest = new TokenRequestViewModel
        {
            Email = "user@example.com",
            Password = "User.1234"
        };

        var tokenResponse = await client.PostAsJsonAsync("api/Auth/CreateToken", tokenRequest);

        if (!tokenResponse.IsSuccessStatusCode)
            return StatusCode((int)tokenResponse.StatusCode, await tokenResponse.Content.ReadAsStringAsync());

        var tokenResult = await tokenResponse.Content.ReadFromJsonAsync<Result<TokenViewModel>>();
        var accessToken = tokenResult?.Data?.AccessToken;

        if (string.IsNullOrEmpty(accessToken))
            return BadRequest("Access token is null or empty.");

        using var httpRequest = new HttpRequestMessage(HttpMethod.Get, "api/Product/GetList");
        httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var httpResponse = await client.SendAsync(httpRequest);

        if (!httpResponse.IsSuccessStatusCode)
            return StatusCode((int)httpResponse.StatusCode, await httpResponse.Content.ReadAsStringAsync());

        var products = await httpResponse.Content.ReadAsStringAsync();
        return Content(products, "application/json");
    }
}
