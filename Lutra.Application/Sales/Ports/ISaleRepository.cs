using Lutra.Application.Sales.UseCases.Sale;
using Lutra.Domain.Sales;

namespace Lutra.Application.Sales.Ports;

public interface ISaleRepository
{
    Task<IEnumerable<Sale>> GetAllAsync(SaleFilters? filters = null);
    Task<Sale?> GetByIdAsync(Guid id);
    Task<IEnumerable<Sale>> GetByCustomerAsync(Guid customerId);
    Task AddAsync(Sale sale);
    Task UpdateAsync(Sale sale);
}
