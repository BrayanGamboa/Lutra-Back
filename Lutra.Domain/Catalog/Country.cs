namespace Lutra.Domain.Catalog;
public class Country
{
    public int CountryId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    private Country() { }
    public static Country Create(string name) => new Country { Name = name, CreatedAt = DateTime.UtcNow };
    public void Update(string name) { Name = name; UpdatedAt = DateTime.UtcNow; }
}
