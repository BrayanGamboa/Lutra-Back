using Lutra.Application.Catalog.Ports;

namespace Lutra.Application.Catalog.UseCases.City;

public class GetCitiesByDepartmentUseCase(ICityRepository cityRepository)
{
    public async Task<IEnumerable<CityResponse>> ExecuteAsync(int departmentId)
    {
        var cities = await cityRepository.GetByDepartmentAsync(departmentId);
        return cities.Select(CityResponse.FromDomain);
    }
}
