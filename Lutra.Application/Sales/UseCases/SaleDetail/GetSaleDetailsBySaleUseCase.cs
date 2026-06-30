using Lutra.Application.Sales.Ports;

namespace Lutra.Application.Sales.UseCases.SaleDetail;

public class GetSaleDetailsBySaleUseCase(ISaleDetailRepository saleDetailRepository)
{
    public async Task<IEnumerable<SaleDetailResponse>> ExecuteAsync(Guid saleId)
    {
        var details = await saleDetailRepository.GetBySaleAsync(saleId);
        return details.Select(SaleDetailResponse.FromDomain);
    }
}
