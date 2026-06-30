using Lutra.Application.Catalog.Ports;

namespace Lutra.Application.Catalog.UseCases.Department;

public class GetAllDepartmentsUseCase(IDepartmentRepository departmentRepository)
{
    public async Task<IEnumerable<DepartmentResponse>> ExecuteAsync()
    {
        var departments = await departmentRepository.GetAllAsync();
        return departments.Select(DepartmentResponse.FromDomain);
    }
}
