namespace AuthServer.Domain.DTOs;

public class TokenDto
{
    public string AccessToken { get; set; } = null!;
    public DateTime AccessTokenExpire { get; set; }
    public string RefreshToken { get; set; } = null!;
    public DateTime RefreshTokenExpire{ get; set; }
}
