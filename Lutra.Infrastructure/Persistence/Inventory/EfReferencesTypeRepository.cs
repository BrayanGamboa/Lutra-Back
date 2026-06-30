using Lutra.Application.Inventory.Ports;
using Lutra.Domain.Inventory;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence.Inventory;

public class EfReferencesTypeRepository : IReferencesTypeRepository
{
    private readonly AppDbContext _context;

    public EfReferencesTypeRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<ReferencesType>> GetAllAsync() =>
        await _context.ReferencesTypes.ToListAsync();

    public async Task<ReferencesType?> GetByIdAsync(int id) =>
        await _context.ReferencesTypes.FindAsync(id);

    public async Task<bool> ExistsAsync(string name) =>
        await _context.ReferencesTypes.AnyAsync(r => r.Name == name);

    public async Task AddAsync(ReferencesType referencesType)
    {
        await _context.ReferencesTypes.AddAsync(referencesType);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ReferencesType referencesType)
    {
        var tracked = await _context.ReferencesTypes.FindAsync(referencesType.ReferenceTypeId)
            ?? throw new KeyNotFoundException($"Tipo de referencia {referencesType.ReferenceTypeId} no encontrado");

        tracked.Update(referencesType.Name, referencesType.Description);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ReferencesType referencesType)
    {
        _context.ReferencesTypes.Remove(referencesType);
        await _context.SaveChangesAsync();
    }
}
