using Lutra.Application.Sales.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Sales.UseCases.SaleDetail;

public class GetSaleDetailByIdUseCase(ISaleDetailRepository saleDetailRepository)
{
    public async Task<SaleDetailResponse> ExecuteAsync(int id)
    {
        var detail = await saleDetailRepository.GetByIdAsync(id);
        if (detail is null)
            throw new DomainException("Detalle de venta no encontrado");

        return SaleDetailResponse.FromDomain(detail);
    }
}
