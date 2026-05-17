namespace AuthServer.Domain.DTOs;
public class ClientTokenDto
{
    public string AccessToken { get; set; } = null!;
    public DateTime AccessTokenExpire { get; set; }
}
