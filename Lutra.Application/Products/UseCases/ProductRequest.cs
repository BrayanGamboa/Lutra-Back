namespace Lutra.Application.Products.UseCases;

public record ProductRequest(
    string Name,
    string? Description,
    string Sku,
    decimal Price,
    decimal? Cost,
    int? SupplierId,
    int? CategoryId,
    bool IsActive = true);
