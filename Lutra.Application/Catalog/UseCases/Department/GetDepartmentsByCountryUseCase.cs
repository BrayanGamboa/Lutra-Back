using Lutra.Application.Catalog.Ports;

namespace Lutra.Application.Catalog.UseCases.Department;

public class GetDepartmentsByCountryUseCase(IDepartmentRepository departmentRepository)
{
    public async Task<IEnumerable<DepartmentResponse>> ExecuteAsync(int countryId)
    {
        var departments = await departmentRepository.GetByCountryAsync(countryId);
        return departments.Select(DepartmentResponse.FromDomain);
    }
}
