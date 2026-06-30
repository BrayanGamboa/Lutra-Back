using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.Department;

public class GetDepartmentByIdUseCase(IDepartmentRepository departmentRepository)
{
    public async Task<DepartmentResponse> ExecuteAsync(int departmentId)
    {
        var department = await departmentRepository.GetByIdAsync(departmentId);
        if (department is null)
            throw new DomainException("Departamento no encontrado");

        return DepartmentResponse.FromDomain(department);
    }
}
