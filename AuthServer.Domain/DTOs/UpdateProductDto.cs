namespace AuthServer.Domain.DTOs;

public class UpdateProductDto
{
    public string Id { get; set; } = default!;
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public int? Quantity { get; set; }
    public string? Color { get; set; }
    public string? CategoryId { get; set; }
}
