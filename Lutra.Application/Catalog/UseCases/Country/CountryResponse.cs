namespace Lutra.Application.Catalog.UseCases.Country;

public record CountryResponse(int CountryId, string Name, DateTime? CreatedAt)
{
    public static CountryResponse FromDomain(Domain.Catalog.Country country) =>
        new(country.CountryId, country.Name, country.CreatedAt);
}
