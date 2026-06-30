using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence.Catalog;

public class EfMethodPaymentRepository(AppDbContext context) : IMethodPaymentRepository
{
    public async Task<IEnumerable<MethodPayment>> GetAllAsync() =>
        await context.MethodPayments.ToListAsync();

    public async Task<MethodPayment?> GetByIdAsync(int paymentMethodId) =>
        await context.MethodPayments.FindAsync(paymentMethodId);

    public async Task<bool> ExistsAsync(string name) =>
        await context.MethodPayments.AnyAsync(m => m.Name == name);

    public async Task AddAsync(MethodPayment methodPayment)
    {
        await context.MethodPayments.AddAsync(methodPayment);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(MethodPayment methodPayment)
    {
        var tracked = await context.MethodPayments.FindAsync(methodPayment.PaymentMethodId)
            ?? throw new KeyNotFoundException($"MethodPayment {methodPayment.PaymentMethodId} not found");

        tracked.Update(methodPayment.Name);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(MethodPayment methodPayment)
    {
        context.MethodPayments.Remove(methodPayment);
        await context.SaveChangesAsync();
    }
}
