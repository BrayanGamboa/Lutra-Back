using Lutra.Domain.Inventory;

namespace Lutra.Application.Inventory.Ports;

public interface IInventoryMovementRepository
{
    Task<IEnumerable<InventoryMovement>> GetAllAsync();
    Task<InventoryMovement?> GetByIdAsync(int id);
    Task<IEnumerable<InventoryMovement>> GetByProductAsync(int productId);
    Task AddAsync(InventoryMovement movement);
}
