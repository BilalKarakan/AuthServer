namespace AuthServer.Domain.Entities;

public class Client
{
    public string ClientId { get; set; } = null!;
    public string SecretKey { get; set; } = null!;
    public List<ClientAudience> Audiences { get; set; } = null!;
}
