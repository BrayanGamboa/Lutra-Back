using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.Department;

public class CreateDepartmentUseCase(IDepartmentRepository departmentRepository)
{
    public async Task<DepartmentResponse> ExecuteAsync(DepartmentRequest request)
    {
        var exists = await departmentRepository.ExistsAsync(request.Name, request.CountryId);
        if (exists)
            throw new DomainException("El departamento ya existe en este país");

        var department = Domain.Catalog.Department.Create(request.Name, request.CountryId);
        await departmentRepository.AddAsync(department);

        return DepartmentResponse.FromDomain(department);
    }
}
