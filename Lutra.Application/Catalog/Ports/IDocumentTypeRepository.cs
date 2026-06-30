using Lutra.Domain.Catalog;

namespace Lutra.Application.Catalog.Ports;

public interface IDocumentTypeRepository
{
    Task<IEnumerable<DocumentType>> GetAllAsync();
    Task<DocumentType?> GetByIdAsync(int documentTypeId);
    Task<bool> ExistsAsync(string name);
    Task AddAsync(DocumentType documentType);
    Task UpdateAsync(DocumentType documentType);
    Task DeleteAsync(DocumentType documentType);
}
