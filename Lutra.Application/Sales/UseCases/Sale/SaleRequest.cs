namespace Lutra.Application.Sales.UseCases.Sale;

public record SaleRequest(Guid CustomerId, decimal TotalAmount, int? PaymentMethodId);

public record UpdateSaleStatusRequest(string Status);
