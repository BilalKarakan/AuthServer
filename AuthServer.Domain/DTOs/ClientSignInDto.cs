namespace AuthServer.Domain.DTOs;

public class ClientSignInDto
{
    public string ClientId { get; set; } = null!;
    public string SecretKey { get; set; } = null!;
}
