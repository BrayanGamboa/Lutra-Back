using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence.Catalog;

public class EfCityRepository(AppDbContext context) : ICityRepository
{
    public async Task<IEnumerable<City>> GetAllAsync() =>
        await context.Cities.Include(c => c.Department).ToListAsync();

    public async Task<City?> GetByIdAsync(int cityId) =>
        await context.Cities
            .Include(c => c.Department)
            .FirstOrDefaultAsync(c => c.CityId == cityId);

    public async Task<IEnumerable<City>> GetByDepartmentAsync(int departmentId) =>
        await context.Cities
            .Where(c => c.DepartmentId == departmentId)
            .ToListAsync();

    public async Task<bool> ExistsAsync(string name, int departmentId) =>
        await context.Cities.AnyAsync(c => c.Name == name && c.DepartmentId == departmentId);

    public async Task AddAsync(City city)
    {
        await context.Cities.AddAsync(city);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(City city)
    {
        var tracked = await context.Cities.FindAsync(city.CityId)
            ?? throw new KeyNotFoundException($"City {city.CityId} not found");

        tracked.Update(city.Name, city.DepartmentId);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(City city)
    {
        context.Cities.Remove(city);
        await context.SaveChangesAsync();
    }
}
