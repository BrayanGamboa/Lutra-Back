namespace Lutra.Application.Inventory.UseCases.ReferencesType;

public record ReferencesTypeResponse(int ReferenceTypeId, string Name, string? Description, DateTime? CreatedAt)
{
    public static ReferencesTypeResponse FromDomain(Domain.Inventory.ReferencesType referencesType) =>
        new(referencesType.ReferenceTypeId, referencesType.Name, referencesType.Description, referencesType.CreatedAt);
}
