using Lutra.Domain.Catalog;

namespace Lutra.Application.Catalog.Ports;

public interface ITaxRegimeRepository
{
    Task<IEnumerable<TaxRegime>> GetAllAsync();
    Task<TaxRegime?> GetByIdAsync(int taxRegimeId);
    Task<bool> ExistsAsync(string name);
    Task AddAsync(TaxRegime taxRegime);
    Task UpdateAsync(TaxRegime taxRegime);
    Task DeleteAsync(TaxRegime taxRegime);
}
