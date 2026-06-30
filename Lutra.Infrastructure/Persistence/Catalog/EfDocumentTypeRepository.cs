using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence.Catalog;

public class EfDocumentTypeRepository(AppDbContext context) : IDocumentTypeRepository
{
    public async Task<IEnumerable<DocumentType>> GetAllAsync() =>
        await context.DocumentTypes.ToListAsync();

    public async Task<DocumentType?> GetByIdAsync(int documentTypeId) =>
        await context.DocumentTypes.FindAsync(documentTypeId);

    public async Task<bool> ExistsAsync(string name) =>
        await context.DocumentTypes.AnyAsync(d => d.Name == name);

    public async Task AddAsync(DocumentType documentType)
    {
        await context.DocumentTypes.AddAsync(documentType);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DocumentType documentType)
    {
        var tracked = await context.DocumentTypes.FindAsync(documentType.DocumentTypeId)
            ?? throw new KeyNotFoundException($"DocumentType {documentType.DocumentTypeId} not found");

        tracked.Update(documentType.Name);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(DocumentType documentType)
    {
        context.DocumentTypes.Remove(documentType);
        await context.SaveChangesAsync();
    }
}
