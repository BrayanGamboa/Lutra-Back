namespace Lutra.Application.Inventory.UseCases.InventoryMovement;

public record InventoryMovementResponse(
    int MovementId,
    int ProductId,
    int Quantity,
    string MovementType,
    int ReferenceId,
    DateTime? CreatedAt)
{
    public static InventoryMovementResponse FromDomain(Domain.Inventory.InventoryMovement movement) =>
        new(movement.MovementId, movement.ProductId, movement.Quantity, movement.MovementType, movement.ReferenceId, movement.CreatedAt);
}
