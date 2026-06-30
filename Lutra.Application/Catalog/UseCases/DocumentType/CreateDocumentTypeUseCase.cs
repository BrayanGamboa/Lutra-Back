using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.DocumentType;

public class CreateDocumentTypeUseCase(IDocumentTypeRepository documentTypeRepository)
{
    public async Task<DocumentTypeResponse> ExecuteAsync(DocumentTypeRequest request)
    {
        var exists = await documentTypeRepository.ExistsAsync(request.Name);
        if (exists)
            throw new DomainException("El tipo de documento ya existe");

        var documentType = Domain.Catalog.DocumentType.Create(request.Name);
        await documentTypeRepository.AddAsync(documentType);

        return DocumentTypeResponse.FromDomain(documentType);
    }
}
