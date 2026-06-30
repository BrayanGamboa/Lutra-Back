using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.Department;

public class DeleteDepartmentUseCase(IDepartmentRepository departmentRepository)
{
    public async Task ExecuteAsync(int departmentId)
    {
        var department = await departmentRepository.GetByIdAsync(departmentId);
        if (department is null)
            throw new DomainException("Departamento no encontrado");

        await departmentRepository.DeleteAsync(department);
    }
}
