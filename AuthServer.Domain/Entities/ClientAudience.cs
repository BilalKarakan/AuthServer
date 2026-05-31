namespace AuthServer.Domain.Entities;

public class ClientAudience
{
    public string ClientId { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public Client Client { get; set; }
}
