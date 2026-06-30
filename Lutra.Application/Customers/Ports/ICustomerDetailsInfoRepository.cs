using Lutra.Domain.Sales;

namespace Lutra.Application.Customers.Ports;

public interface ICustomerDetailsInfoRepository
{
    Task<CustomerDetailsInfo?> GetByUserIdAsync(Guid userId);
    Task<CustomerDetailsInfo?> GetByIdAsync(int id);
    Task AddAsync(CustomerDetailsInfo customerDetailsInfo);
    Task UpdateAsync(CustomerDetailsInfo customerDetailsInfo);
}
