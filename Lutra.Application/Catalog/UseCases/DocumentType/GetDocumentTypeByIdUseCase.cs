using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.DocumentType;

public class GetDocumentTypeByIdUseCase(IDocumentTypeRepository documentTypeRepository)
{
    public async Task<DocumentTypeResponse> ExecuteAsync(int documentTypeId)
    {
        var documentType = await documentTypeRepository.GetByIdAsync(documentTypeId);
        if (documentType is null)
            throw new DomainException("Tipo de documento no encontrado");

        return DocumentTypeResponse.FromDomain(documentType);
    }
}
