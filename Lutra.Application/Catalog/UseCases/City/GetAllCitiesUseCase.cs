using Lutra.Application.Catalog.Ports;

namespace Lutra.Application.Catalog.UseCases.City;

public class GetAllCitiesUseCase(ICityRepository cityRepository)
{
    public async Task<IEnumerable<CityResponse>> ExecuteAsync()
    {
        var cities = await cityRepository.GetAllAsync();
        return cities.Select(CityResponse.FromDomain);
    }
}
