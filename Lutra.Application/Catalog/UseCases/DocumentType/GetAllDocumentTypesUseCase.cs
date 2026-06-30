using Lutra.Application.Catalog.Ports;

namespace Lutra.Application.Catalog.UseCases.DocumentType;

public class GetAllDocumentTypesUseCase(IDocumentTypeRepository documentTypeRepository)
{
    public async Task<IEnumerable<DocumentTypeResponse>> ExecuteAsync()
    {
        var documentTypes = await documentTypeRepository.GetAllAsync();
        return documentTypes.Select(DocumentTypeResponse.FromDomain);
    }
}
