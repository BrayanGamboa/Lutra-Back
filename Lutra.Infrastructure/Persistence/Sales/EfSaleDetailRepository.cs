using Lutra.Application.Sales.Ports;
using Lutra.Domain.Sales;
using Lutra.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence.Sales;

public class EfSaleDetailRepository : ISaleDetailRepository
{
    private readonly AppDbContext _context;

    public EfSaleDetailRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<SaleDetail>> GetBySaleAsync(Guid saleId) =>
        await _context.SaleDetails
            .Where(sd => sd.SaleId == saleId)
            .ToListAsync();

    public async Task<SaleDetail?> GetByIdAsync(int id) =>
        await _context.SaleDetails.FindAsync(id);

    public async Task AddAsync(SaleDetail saleDetail)
    {
        await _context.SaleDetails.AddAsync(saleDetail);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<SaleDetail> saleDetails)
    {
        await _context.SaleDetails.AddRangeAsync(saleDetails);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(SaleDetail saleDetail)
    {
        _context.SaleDetails.Remove(saleDetail);
        await _context.SaveChangesAsync();
    }
}
