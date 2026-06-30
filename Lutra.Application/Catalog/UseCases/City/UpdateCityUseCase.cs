using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.City;

public class UpdateCityUseCase(ICityRepository cityRepository)
{
    public async Task<CityResponse> ExecuteAsync(int cityId, CityRequest request)
    {
        var city = await cityRepository.GetByIdAsync(cityId);
        if (city is null)
            throw new DomainException("Ciudad no encontrada");

        city.Update(request.Name, request.DepartmentId);
        await cityRepository.UpdateAsync(city);

        return CityResponse.FromDomain(city);
    }
}
