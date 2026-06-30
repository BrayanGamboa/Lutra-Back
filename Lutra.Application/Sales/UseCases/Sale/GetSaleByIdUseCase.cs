using Lutra.Application.Sales.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Sales.UseCases.Sale;

public class GetSaleByIdUseCase(ISaleRepository saleRepository)
{
    public async Task<SaleResponse> ExecuteAsync(Guid id)
    {
        var sale = await saleRepository.GetByIdAsync(id);
        if (sale is null)
            throw new DomainException("Venta no encontrada");

        return SaleResponse.FromDomain(sale);
    }
}
