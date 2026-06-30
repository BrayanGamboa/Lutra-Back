namespace Lutra.Domain.Inventory;
public class ReferencesType
{
    public int ReferenceTypeId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    private ReferencesType() { }
    public static ReferencesType Create(string name, string? description) => new ReferencesType { Name = name, Description = description, CreatedAt = DateTime.UtcNow };
    public void Update(string name, string? description) { Name = name; Description = description; UpdatedAt = DateTime.UtcNow; }
}
