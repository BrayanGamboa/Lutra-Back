using Lutra.Application.Inventory.Ports;
using Lutra.Domain.Inventory;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence.Inventory;

public class EfCategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public EfCategoryRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Category>> GetAllAsync() =>
        await _context.Categories.ToListAsync();

    public async Task<Category?> GetByIdAsync(int id) =>
        await _context.Categories.FindAsync(id);

    public async Task<bool> ExistsAsync(string name) =>
        await _context.Categories.AnyAsync(c => c.Name == name);

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        var tracked = await _context.Categories.FindAsync(category.CategoryId)
            ?? throw new KeyNotFoundException($"Categoría {category.CategoryId} no encontrada");

        tracked.Update(category.Name, category.Description);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}
