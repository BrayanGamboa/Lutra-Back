using Lutra.Application.Sales.Ports;

namespace Lutra.Application.Sales.UseCases.Sale;

public class CreateSaleUseCase(ISaleRepository saleRepository)
{
    public async Task<SaleResponse> ExecuteAsync(SaleRequest request)
    {
        var sale = Domain.Sales.Sale.Create(request.CustomerId, request.TotalAmount, request.PaymentMethodId);
        await saleRepository.AddAsync(sale);
        return SaleResponse.FromDomain(sale);
    }
}
