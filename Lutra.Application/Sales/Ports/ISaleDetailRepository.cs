using Lutra.Domain.Sales;

namespace Lutra.Application.Sales.Ports;

public interface ISaleDetailRepository
{
    Task<IEnumerable<SaleDetail>> GetBySaleAsync(Guid saleId);
    Task<SaleDetail?> GetByIdAsync(int id);
    Task AddAsync(SaleDetail saleDetail);
    Task AddRangeAsync(IEnumerable<SaleDetail> saleDetails);
    Task DeleteAsync(SaleDetail saleDetail);
}
