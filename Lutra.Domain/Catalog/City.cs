namespace Lutra.Domain.Catalog;
public class City
{
    public int CityId { get; set; }
    public string Name { get; set; } = null!;
    public int DepartmentId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public virtual Department? Department { get; set; }
    private City() { }
    public static City Create(string name, int departmentId) => new City { Name = name, DepartmentId = departmentId, CreatedAt = DateTime.UtcNow };
    public void Update(string name, int departmentId) { Name = name; DepartmentId = departmentId; UpdatedAt = DateTime.UtcNow; }
}
