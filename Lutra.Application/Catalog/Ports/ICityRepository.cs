using Lutra.Domain.Catalog;

namespace Lutra.Application.Catalog.Ports;

public interface ICityRepository
{
    Task<IEnumerable<City>> GetAllAsync();
    Task<City?> GetByIdAsync(int cityId);
    Task<IEnumerable<City>> GetByDepartmentAsync(int departmentId);
    Task<bool> ExistsAsync(string name, int departmentId);
    Task AddAsync(City city);
    Task UpdateAsync(City city);
    Task DeleteAsync(City city);
}
