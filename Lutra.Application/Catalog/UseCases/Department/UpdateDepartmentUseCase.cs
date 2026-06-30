using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.Department;

public class UpdateDepartmentUseCase(IDepartmentRepository departmentRepository)
{
    public async Task<DepartmentResponse> ExecuteAsync(int departmentId, DepartmentRequest request)
    {
        var department = await departmentRepository.GetByIdAsync(departmentId);
        if (department is null)
            throw new DomainException("Departamento no encontrado");

        department.Update(request.Name, request.CountryId);
        await departmentRepository.UpdateAsync(department);

        return DepartmentResponse.FromDomain(department);
    }
}
