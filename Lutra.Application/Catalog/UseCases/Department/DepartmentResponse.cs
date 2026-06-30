namespace Lutra.Application.Catalog.UseCases.Department;

public record DepartmentResponse(int DepartmentId, string Name, int CountryId, DateTime? CreatedAt)
{
    public static DepartmentResponse FromDomain(Domain.Catalog.Department department) =>
        new(department.DepartmentId, department.Name, department.CountryId, department.CreatedAt);
}
