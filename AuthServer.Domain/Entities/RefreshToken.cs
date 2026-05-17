namespace AuthServer.Domain.Entities;

public class RefreshToken
{
    public string UserId { get; set; } = null!;
    public string Token { get; set; } = null!;
    public DateTime Expire { get; set; }
}
