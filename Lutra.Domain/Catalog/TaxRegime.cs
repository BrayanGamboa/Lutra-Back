namespace Lutra.Domain.Catalog;
public class TaxRegime
{
    public int TaxRegimeId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    private TaxRegime() { }
    public static TaxRegime Create(string name, string? description) => new TaxRegime { Name = name, Description = description, CreatedAt = DateTime.UtcNow };
    public void Update(string name, string? description) { Name = name; Description = description; UpdatedAt = DateTime.UtcNow; }
}
