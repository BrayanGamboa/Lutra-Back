using Lutra.Application.Products.Ports;
using Lutra.Domain.Inventory;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence.Products;

public class EfProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public EfProductRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Product>> GetAllAsync() =>
        await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .ToListAsync();

    public async Task<Product?> GetByIdAsync(int id) =>
        await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .FirstOrDefaultAsync(p => p.ProductId == id);

    public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId) =>
        await _context.Products
            .Where(p => p.CategoryId == categoryId)
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .ToListAsync();

    public async Task<IEnumerable<Product>> GetBySupplierAsync(int supplierId) =>
        await _context.Products
            .Where(p => p.SupplierId == supplierId)
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .ToListAsync();

    public async Task<bool> ExistsBySkuAsync(string sku) =>
        await _context.Products.AnyAsync(p => p.Sku == sku);

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        var tracked = await _context.Products.FindAsync(product.ProductId)
            ?? throw new KeyNotFoundException($"Producto {product.ProductId} no encontrado");

        tracked.Update(product.Name, product.Description, product.Price, product.Cost, product.SupplierId, product.CategoryId, product.IsActive);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}
