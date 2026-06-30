using Lutra.Domain.Catalog;

namespace Lutra.Application.Catalog.Ports;

public interface IMethodPaymentRepository
{
    Task<IEnumerable<MethodPayment>> GetAllAsync();
    Task<MethodPayment?> GetByIdAsync(int paymentMethodId);
    Task<bool> ExistsAsync(string name);
    Task AddAsync(MethodPayment methodPayment);
    Task UpdateAsync(MethodPayment methodPayment);
    Task DeleteAsync(MethodPayment methodPayment);
}
