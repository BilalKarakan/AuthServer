using AuthServer.Domain.Entities;

namespace AuthServer.Domain.DTOs;

public class CategoryDto
{
    public string Name { get; set; } = null!;
    public ICollection<ProductDto>? Products { get; set; }
}
