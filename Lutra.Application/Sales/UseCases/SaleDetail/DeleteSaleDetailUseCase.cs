using Lutra.Application.Sales.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Sales.UseCases.SaleDetail;

public class DeleteSaleDetailUseCase(ISaleDetailRepository saleDetailRepository)
{
    public async Task ExecuteAsync(int id)
    {
        var detail = await saleDetailRepository.GetByIdAsync(id);
        if (detail is null)
            throw new DomainException("Detalle de venta no encontrado");

        await saleDetailRepository.DeleteAsync(detail);
    }
}
