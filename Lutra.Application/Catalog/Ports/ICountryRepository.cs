using Lutra.Domain.Catalog;

namespace Lutra.Application.Catalog.Ports;

public interface ICountryRepository
{
    Task<IEnumerable<Country>> GetAllAsync();
    Task<Country?> GetByIdAsync(int countryId);
    Task<bool> ExistsAsync(string name);
    Task AddAsync(Country country);
    Task UpdateAsync(Country country);
    Task DeleteAsync(Country country);
}
