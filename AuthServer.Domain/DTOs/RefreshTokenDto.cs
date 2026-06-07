namespace AuthServer.Domain.DTOs;

public class RefreshTokenDto
{
    public string UserId { get; set; } = null!;
    public string Token { get; set; } = null!;
}
