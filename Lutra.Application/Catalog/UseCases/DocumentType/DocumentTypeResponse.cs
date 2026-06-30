namespace Lutra.Application.Catalog.UseCases.DocumentType;

public record DocumentTypeResponse(int DocumentTypeId, string Name, DateTime? CreatedAt)
{
    public static DocumentTypeResponse FromDomain(Domain.Catalog.DocumentType documentType) =>
        new(documentType.DocumentTypeId, documentType.Name, documentType.CreatedAt);
}
