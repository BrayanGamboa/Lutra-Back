namespace Lutra.Application.Inventory.UseCases.InventoryMovement;

public record InventoryMovementRequest(int ProductId, int Quantity, string MovementType, int ReferenceId);
