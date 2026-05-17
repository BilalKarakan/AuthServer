namespace AuthServer.Domain.DTOs;

public class ClientDto
{
    public string ClientId { get; set; } = null!;
    public string SecretKey { get; set; } = null!;
    public List<string> Audiences { get; set; } = null!;
}
