using Lutra.Application.Sales.Ports;

namespace Lutra.Application.Sales.UseCases.Sale;

public class GetSalesByCustomerUseCase(ISaleRepository saleRepository)
{
    public async Task<IEnumerable<SaleResponse>> ExecuteAsync(Guid customerId)
    {
        var sales = await saleRepository.GetByCustomerAsync(customerId);
        return sales.Select(SaleResponse.FromDomain);
    }
}
