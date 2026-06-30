namespace Lutra.Application.Catalog.UseCases.TaxRegime;

public record TaxRegimeResponse(int TaxRegimeId, string Name, string? Description, DateTime? CreatedAt)
{
    public static TaxRegimeResponse FromDomain(Domain.Catalog.TaxRegime taxRegime) =>
        new(taxRegime.TaxRegimeId, taxRegime.Name, taxRegime.Description, taxRegime.CreatedAt);
}
