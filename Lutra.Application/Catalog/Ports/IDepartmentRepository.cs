using Lutra.Domain.Catalog;

namespace Lutra.Application.Catalog.Ports;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> GetAllAsync();
    Task<Department?> GetByIdAsync(int departmentId);
    Task<IEnumerable<Department>> GetByCountryAsync(int countryId);
    Task<bool> ExistsAsync(string name, int countryId);
    Task AddAsync(Department department);
    Task UpdateAsync(Department department);
    Task DeleteAsync(Department department);
}
