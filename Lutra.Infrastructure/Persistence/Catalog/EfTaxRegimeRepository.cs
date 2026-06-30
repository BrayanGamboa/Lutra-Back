using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence.Catalog;

public class EfTaxRegimeRepository(AppDbContext context) : ITaxRegimeRepository
{
    public async Task<IEnumerable<TaxRegime>> GetAllAsync() =>
        await context.TaxRegimes.ToListAsync();

    public async Task<TaxRegime?> GetByIdAsync(int taxRegimeId) =>
        await context.TaxRegimes.FindAsync(taxRegimeId);

    public async Task<bool> ExistsAsync(string name) =>
        await context.TaxRegimes.AnyAsync(t => t.Name == name);

    public async Task AddAsync(TaxRegime taxRegime)
    {
        await context.TaxRegimes.AddAsync(taxRegime);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TaxRegime taxRegime)
    {
        var tracked = await context.TaxRegimes.FindAsync(taxRegime.TaxRegimeId)
            ?? throw new KeyNotFoundException($"TaxRegime {taxRegime.TaxRegimeId} not found");

        tracked.Update(taxRegime.Name, taxRegime.Description);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TaxRegime taxRegime)
    {
        context.TaxRegimes.Remove(taxRegime);
        await context.SaveChangesAsync();
    }
}
