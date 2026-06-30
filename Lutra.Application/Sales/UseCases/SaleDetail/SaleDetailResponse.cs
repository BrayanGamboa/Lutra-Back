namespace Lutra.Application.Sales.UseCases.SaleDetail;

public record SaleDetailResponse(
    int SaleDetailId,
    Guid SaleId,
    int ProductId,
    int Quantity,
    decimal UnitPrice,
    decimal? Subtotal,
    DateTime? CreatedAt)
{
    public static SaleDetailResponse FromDomain(Domain.Sales.SaleDetail sd) =>
        new(sd.SaleDetailId, sd.SaleId, sd.ProductId, sd.Quantity, sd.UnitPrice, sd.Subtotal, sd.CreatedAt);
}
