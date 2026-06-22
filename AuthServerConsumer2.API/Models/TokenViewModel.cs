namespace AuthServerConsumer2.API.Models;

public class TokenViewModel
{
    public string AccessToken { get; set; } = null!;
    public DateTime AccessTokenExpire { get; set; }
    public string RefreshToken { get; set; } = null!;
    public DateTime RefreshTokenExpire { get; set; }
}
