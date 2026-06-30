using Lutra.Application.Sales.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Sales.UseCases.Sale;

public class UpdateSaleStatusUseCase(ISaleRepository saleRepository)
{
    public async Task<SaleResponse> ExecuteAsync(Guid id, UpdateSaleStatusRequest request)
    {
        var sale = await saleRepository.GetByIdAsync(id);
        if (sale is null)
            throw new DomainException("Venta no encontrada");

        sale.UpdateStatus(request.Status);
        await saleRepository.UpdateAsync(sale);
        return SaleResponse.FromDomain(sale);
    }
}
