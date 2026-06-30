namespace Lutra.Application.Catalog.UseCases.City;

public record CityResponse(int CityId, string Name, int DepartmentId, DateTime? CreatedAt)
{
    public static CityResponse FromDomain(Domain.Catalog.City city) =>
        new(city.CityId, city.Name, city.DepartmentId, city.CreatedAt);
}
