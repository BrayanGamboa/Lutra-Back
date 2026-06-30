using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.City;

public class CreateCityUseCase(ICityRepository cityRepository)
{
    public async Task<CityResponse> ExecuteAsync(CityRequest request)
    {
        var exists = await cityRepository.ExistsAsync(request.Name, request.DepartmentId);
        if (exists)
            throw new DomainException("La ciudad ya existe en este departamento");

        var city = Domain.Catalog.City.Create(request.Name, request.DepartmentId);
        await cityRepository.AddAsync(city);

        return CityResponse.FromDomain(city);
    }
}
