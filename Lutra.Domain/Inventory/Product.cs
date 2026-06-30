namespace Lutra.Domain.Inventory;
public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Sku { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal? Cost { get; set; }
    public int? SupplierId { get; set; }
    public int? CategoryId { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public virtual Category? Category { get; set; }
    public virtual Supplier? Supplier { get; set; }
    private Product() { }
    public static Product Create(string name, string? description, string sku, decimal price, decimal? cost, int? supplierId, int? categoryId) =>
        new Product { Name = name, Description = description, Sku = sku, Price = price, Cost = cost, SupplierId = supplierId, CategoryId = categoryId, IsActive = true, CreatedAt = DateTime.UtcNow };
    public void Update(string name, string? description, decimal price, decimal? cost, int? supplierId, int? categoryId, bool isActive) {
        Name = name; Description = description; Price = price; Cost = cost; SupplierId = supplierId; CategoryId = categoryId; IsActive = isActive; UpdatedAt = DateTime.UtcNow;
    }
}
