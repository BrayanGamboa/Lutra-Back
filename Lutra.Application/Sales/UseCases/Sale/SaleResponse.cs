namespace Lutra.Application.Sales.UseCases.Sale;

public record SaleResponse(
    Guid SaleId,
    Guid CustomerId,
    decimal TotalAmount,
    int? PaymentMethodId,
    DateTime? SaleDate,
    string? Status,
    DateTime? CreatedAt)
{
    public static SaleResponse FromDomain(Domain.Sales.Sale s) =>
        new(s.SaleId, s.CustomerId, s.TotalAmount, s.PaymentMethodId, s.SaleDate, s.Status, s.CreatedAt);
}
