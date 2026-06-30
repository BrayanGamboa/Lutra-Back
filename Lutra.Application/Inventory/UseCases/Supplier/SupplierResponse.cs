namespace Lutra.Application.Inventory.UseCases.Supplier;

public record SupplierResponse(
    int SupplierId,
    string Name,
    string? ContactName,
    string? Email,
    string? Phone,
    string? Address,
    DateTime? CreatedAt)
{
    public static SupplierResponse FromDomain(Domain.Inventory.Supplier supplier) =>
        new(supplier.SupplierId, supplier.Name, supplier.ContactName, supplier.Email, supplier.Phone, supplier.Address, supplier.CreatedAt);
}
