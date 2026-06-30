namespace Lutra.Domain.Catalog;
public class Department
{
    public int DepartmentId { get; set; }
    public string Name { get; set; } = null!;
    public int CountryId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public virtual Country? Country { get; set; }
    private Department() { }
    public static Department Create(string name, int countryId) => new Department { Name = name, CountryId = countryId, CreatedAt = DateTime.UtcNow };
    public void Update(string name, int countryId) { Name = name; CountryId = countryId; UpdatedAt = DateTime.UtcNow; }
}
