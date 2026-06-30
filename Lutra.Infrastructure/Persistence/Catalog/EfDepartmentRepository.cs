using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence.Catalog;

public class EfDepartmentRepository(AppDbContext context) : IDepartmentRepository
{
    public async Task<IEnumerable<Department>> GetAllAsync() =>
        await context.Departments.Include(d => d.Country).ToListAsync();

    public async Task<Department?> GetByIdAsync(int departmentId) =>
        await context.Departments
            .Include(d => d.Country)
            .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);

    public async Task<IEnumerable<Department>> GetByCountryAsync(int countryId) =>
        await context.Departments
            .Where(d => d.CountryId == countryId)
            .ToListAsync();

    public async Task<bool> ExistsAsync(string name, int countryId) =>
        await context.Departments.AnyAsync(d => d.Name == name && d.CountryId == countryId);

    public async Task AddAsync(Department department)
    {
        await context.Departments.AddAsync(department);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Department department)
    {
        var tracked = await context.Departments.FindAsync(department.DepartmentId)
            ?? throw new KeyNotFoundException($"Department {department.DepartmentId} not found");

        tracked.Update(department.Name, department.CountryId);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Department department)
    {
        context.Departments.Remove(department);
        await context.SaveChangesAsync();
    }
}
