using Lutra.Application.Customers.Ports;
using Lutra.Domain.Sales;
using Lutra.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence.Customers;

public class EfCustomerDetailsInfoRepository : ICustomerDetailsInfoRepository
{
    private readonly AppDbContext _context;

    public EfCustomerDetailsInfoRepository(AppDbContext context) => _context = context;

    public async Task<CustomerDetailsInfo?> GetByUserIdAsync(Guid userId) =>
        await _context.CustomerDetailsInfos.FirstOrDefaultAsync(c => c.UserId == userId);

    public async Task<CustomerDetailsInfo?> GetByIdAsync(int id) =>
        await _context.CustomerDetailsInfos.FindAsync(id);

    public async Task AddAsync(CustomerDetailsInfo customerDetailsInfo)
    {
        await _context.CustomerDetailsInfos.AddAsync(customerDetailsInfo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CustomerDetailsInfo customerDetailsInfo)
    {
        _context.CustomerDetailsInfos.Update(customerDetailsInfo);
        await _context.SaveChangesAsync();
    }
}
