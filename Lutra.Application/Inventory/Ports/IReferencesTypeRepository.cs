using Lutra.Domain.Inventory;

namespace Lutra.Application.Inventory.Ports;

public interface IReferencesTypeRepository
{
    Task<IEnumerable<ReferencesType>> GetAllAsync();
    Task<ReferencesType?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(string name);
    Task AddAsync(ReferencesType referencesType);
    Task UpdateAsync(ReferencesType referencesType);
    Task DeleteAsync(ReferencesType referencesType);
}
