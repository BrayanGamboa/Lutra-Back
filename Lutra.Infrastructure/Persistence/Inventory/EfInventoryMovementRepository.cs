using Lutra.Application.Inventory.Ports;
using Lutra.Domain.Inventory;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence.Inventory;

public class EfInventoryMovementRepository : IInventoryMovementRepository
{
    private readonly AppDbContext _context;

    public EfInventoryMovementRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<InventoryMovement>> GetAllAsync() =>
        await _context.InventoryMovements
            .Include(m => m.Product)
            .Include(m => m.Reference)
            .ToListAsync();

    public async Task<InventoryMovement?> GetByIdAsync(int id) =>
        await _context.InventoryMovements
            .Include(m => m.Product)
            .Include(m => m.Reference)
            .FirstOrDefaultAsync(m => m.MovementId == id);

    public async Task<IEnumerable<InventoryMovement>> GetByProductAsync(int productId) =>
        await _context.InventoryMovements
            .Where(m => m.ProductId == productId)
            .Include(m => m.Product)
            .Include(m => m.Reference)
            .ToListAsync();

    public async Task AddAsync(InventoryMovement movement)
    {
        await _context.InventoryMovements.AddAsync(movement);
        await _context.SaveChangesAsync();
    }
}
