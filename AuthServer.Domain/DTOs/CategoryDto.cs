using AuthServer.Domain.Entities;

namespace AuthServer.Domain.DTOs;

public class CategoryDto : BaseDto
{
    public string Name { get; set; } = null!;
    public ICollection<Product>? Products { get; set; }
}
