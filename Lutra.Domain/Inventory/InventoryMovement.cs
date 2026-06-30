namespace Lutra.Domain.Inventory;
public class InventoryMovement
{
    public int MovementId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string MovementType { get; set; } = null!;
    public int ReferenceId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public virtual Product? Product { get; set; }
    public virtual ReferencesType? Reference { get; set; }
    private InventoryMovement() { }
    public static InventoryMovement Create(int productId, int quantity, string movementType, int referenceId) =>
        new InventoryMovement { ProductId = productId, Quantity = quantity, MovementType = movementType, ReferenceId = referenceId, CreatedAt = DateTime.UtcNow };
}
