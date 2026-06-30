namespace Lutra.Application.Products.UseCases;

public record ProductResponse(
    int ProductId,
    string Name,
    string? Description,
    string Sku,
    decimal Price,
    decimal? Cost,
    int? SupplierId,
    int? CategoryId,
    bool IsActive,
    DateTime? CreatedAt)
{
    public static ProductResponse FromDomain(Domain.Inventory.Product product) =>
        new(product.ProductId, product.Name, product.Description, product.Sku, product.Price, product.Cost, product.SupplierId, product.CategoryId, product.IsActive, product.CreatedAt);
}
