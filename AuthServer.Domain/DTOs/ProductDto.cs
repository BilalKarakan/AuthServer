using AuthServer.Domain.Entities;

namespace AuthServer.Domain.DTOs;

public class ProductDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Color { get; set; } = null!;
    public string CategoryId { get; set; } = null!;
    public CategoryDto Category { get; set; }
}
