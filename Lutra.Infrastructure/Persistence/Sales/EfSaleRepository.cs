using Lutra.Application.Sales.Ports;
using Lutra.Application.Sales.UseCases.Sale;
using Lutra.Domain.Sales;
using Lutra.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence.Sales;

public class EfSaleRepository : ISaleRepository
{
    private readonly AppDbContext _context;

    public EfSaleRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Sale>> GetAllAsync(SaleFilters? filters = null)
    {
        var query = _context.Sales.AsQueryable();

        if (filters is not null)
        {
            if (filters.ClienteId.HasValue)
                query = query.Where(s => s.CustomerId == filters.ClienteId.Value);

            if (filters.FechaDesde.HasValue)
                query = query.Where(s => s.SaleDate >= filters.FechaDesde.Value);

            if (filters.FechaHasta.HasValue)
                query = query.Where(s => s.SaleDate <= filters.FechaHasta.Value);
        }

        return await query.OrderByDescending(s => s.SaleDate).ToListAsync();
    }

    public async Task<Sale?> GetByIdAsync(Guid id) =>
        await _context.Sales.FindAsync(id);

    public async Task<IEnumerable<Sale>> GetByCustomerAsync(Guid customerId) =>
        await _context.Sales
            .Where(s => s.CustomerId == customerId)
            .OrderByDescending(s => s.SaleDate)
            .ToListAsync();

    public async Task AddAsync(Sale sale)
    {
        await _context.Sales.AddAsync(sale);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Sale sale)
    {
        _context.Sales.Update(sale);
        await _context.SaveChangesAsync();
    }
}
