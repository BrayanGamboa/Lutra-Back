using Lutra.Application.Inventory.Ports;

namespace Lutra.Application.Inventory.UseCases.InventoryMovement;

public class CreateInventoryMovementUseCase(IInventoryMovementRepository inventoryMovementRepository)
{
    public async Task<InventoryMovementResponse> ExecuteAsync(InventoryMovementRequest request)
    {
        var movement = Domain.Inventory.InventoryMovement.Create(request.ProductId, request.Quantity, request.MovementType, request.ReferenceId);
        await inventoryMovementRepository.AddAsync(movement);

        return InventoryMovementResponse.FromDomain(movement);
    }
}
