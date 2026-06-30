using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence.Catalog;

public class EfCountryRepository(AppDbContext context) : ICountryRepository
{
    public async Task<IEnumerable<Country>> GetAllAsync() =>
        await context.Countries.ToListAsync();

    public async Task<Country?> GetByIdAsync(int countryId) =>
        await context.Countries.FindAsync(countryId);

    public async Task<bool> ExistsAsync(string name) =>
        await context.Countries.AnyAsync(c => c.Name == name);

    public async Task AddAsync(Country country)
    {
        await context.Countries.AddAsync(country);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Country country)
    {
        var tracked = await context.Countries.FindAsync(country.CountryId)
            ?? throw new KeyNotFoundException($"Country {country.CountryId} not found");

        tracked.Update(country.Name);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Country country)
    {
        context.Countries.Remove(country);
        await context.SaveChangesAsync();
    }
}
