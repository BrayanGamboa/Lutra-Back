using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.DocumentType;

public class DeleteDocumentTypeUseCase(IDocumentTypeRepository documentTypeRepository)
{
    public async Task ExecuteAsync(int documentTypeId)
    {
        var documentType = await documentTypeRepository.GetByIdAsync(documentTypeId);
        if (documentType is null)
            throw new DomainException("Tipo de documento no encontrado");

        await documentTypeRepository.DeleteAsync(documentType);
    }
}
