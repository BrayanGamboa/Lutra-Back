using Lutra.Application.Inventory.Ports;

namespace Lutra.Application.Inventory.UseCases.InventoryMovement;

public class GetInventoryMovementsByProductUseCase(IInventoryMovementRepository inventoryMovementRepository)
{
    public async Task<IEnumerable<InventoryMovementResponse>> ExecuteAsync(int productId)
    {
        var movements = await inventoryMovementRepository.GetByProductAsync(productId);
        return movements.Select(InventoryMovementResponse.FromDomain);
    }
}
