using Lutra.Application.Inventory.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Inventory.UseCases.InventoryMovement;

public class GetInventoryMovementByIdUseCase(IInventoryMovementRepository inventoryMovementRepository)
{
    public async Task<InventoryMovementResponse> ExecuteAsync(int id)
    {
        var movement = await inventoryMovementRepository.GetByIdAsync(id);
        if (movement is null)
        {
            throw new DomainException("Movimiento de inventario no encontrado");
        }

        return InventoryMovementResponse.FromDomain(movement);
    }
}
