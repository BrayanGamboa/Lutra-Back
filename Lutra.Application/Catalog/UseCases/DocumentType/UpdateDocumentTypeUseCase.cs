using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.DocumentType;

public class UpdateDocumentTypeUseCase(IDocumentTypeRepository documentTypeRepository)
{
    public async Task<DocumentTypeResponse> ExecuteAsync(int documentTypeId, DocumentTypeRequest request)
    {
        var documentType = await documentTypeRepository.GetByIdAsync(documentTypeId);
        if (documentType is null)
            throw new DomainException("Tipo de documento no encontrado");

        documentType.Update(request.Name);
        await documentTypeRepository.UpdateAsync(documentType);

        return DocumentTypeResponse.FromDomain(documentType);
    }
}
