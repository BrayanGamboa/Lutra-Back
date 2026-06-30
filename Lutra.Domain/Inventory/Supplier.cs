namespace Lutra.Domain.Inventory;
public class Supplier
{
    public int SupplierId { get; set; }
    public string Name { get; set; } = null!;
    public string? ContactName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    private Supplier() { }
    public static Supplier Create(string name, string? contactName, string? email, string? phone, string? address) => new Supplier { Name = name, ContactName = contactName, Email = email, Phone = phone, Address = address, CreatedAt = DateTime.UtcNow };
    public void Update(string name, string? contactName, string? email, string? phone, string? address) { Name = name; ContactName = contactName; Email = email; Phone = phone; Address = address; UpdatedAt = DateTime.UtcNow; }
}
