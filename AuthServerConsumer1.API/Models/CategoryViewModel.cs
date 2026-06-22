namespace AuthServerConsumer1.API.Models;

public class CategoryViewModel
{
    public string Name { get; set; } = null!;
    public ICollection<ProductViewModel>? Products { get; set; }
}
