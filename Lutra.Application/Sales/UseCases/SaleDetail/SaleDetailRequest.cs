namespace Lutra.Application.Sales.UseCases.SaleDetail;

public record SaleDetailRequest(Guid SaleId, int ProductId, int Quantity, decimal UnitPrice);
