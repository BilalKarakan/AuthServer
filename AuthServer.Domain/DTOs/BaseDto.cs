namespace AuthServer.Domain.DTOs;

public abstract class BaseDto
{
    public string Id { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
