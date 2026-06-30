using Lutra.Application.Inventory.Ports;
using Lutra.Domain.Inventory;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence.Inventory;

public class EfSupplierRepository : ISupplierRepository
{
    private readonly AppDbContext _context;

    public EfSupplierRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Supplier>> GetAllAsync() =>
        await _context.Suppliers.ToListAsync();

    public async Task<Supplier?> GetByIdAsync(int id) =>
        await _context.Suppliers.FindAsync(id);

    public async Task<bool> ExistsAsync(string name) =>
        await _context.Suppliers.AnyAsync(s => s.Name == name);

    public async Task AddAsync(Supplier supplier)
    {
        await _context.Suppliers.AddAsync(supplier);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Supplier supplier)
    {
        var tracked = await _context.Suppliers.FindAsync(supplier.SupplierId)
            ?? throw new KeyNotFoundException($"Proveedor {supplier.SupplierId} no encontrado");

        tracked.Update(supplier.Name, supplier.ContactName, supplier.Email, supplier.Phone, supplier.Address);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Supplier supplier)
    {
        _context.Suppliers.Remove(supplier);
        await _context.SaveChangesAsync();
    }
}
