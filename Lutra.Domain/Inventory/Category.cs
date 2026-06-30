namespace Lutra.Domain.Inventory;
public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    private Category() { }
    public static Category Create(string name, string? description) => new Category { Name = name, Description = description, CreatedAt = DateTime.UtcNow };
    public void Update(string name, string? description) { Name = name; Description = description; UpdatedAt = DateTime.UtcNow; }
}
