using Lutra.Application.Sales.Ports;

namespace Lutra.Application.Sales.UseCases.SaleDetail;

public class CreateSaleDetailUseCase(ISaleDetailRepository saleDetailRepository)
{
    public async Task<SaleDetailResponse> ExecuteAsync(SaleDetailRequest request)
    {
        var detail = Domain.Sales.SaleDetail.Create(
            request.SaleId,
            request.ProductId,
            request.Quantity,
            request.UnitPrice);

        await saleDetailRepository.AddAsync(detail);
        return SaleDetailResponse.FromDomain(detail);
    }
}
