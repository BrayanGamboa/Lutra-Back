using Lutra.Application.Inventory.Ports;

namespace Lutra.Application.Inventory.UseCases.InventoryMovement;

public class GetAllInventoryMovementsUseCase(IInventoryMovementRepository inventoryMovementRepository)
{
    public async Task<IEnumerable<InventoryMovementResponse>> ExecuteAsync()
    {
        var movements = await inventoryMovementRepository.GetAllAsync();
        return movements.Select(InventoryMovementResponse.FromDomain);
    }
}
