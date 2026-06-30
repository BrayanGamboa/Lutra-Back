namespace Lutra.Application.Inventory.UseCases.Supplier;

public record SupplierRequest(string Name, string? ContactName, string? Email, string? Phone, string? Address);
