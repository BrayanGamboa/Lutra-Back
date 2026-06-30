using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.City;

public class DeleteCityUseCase(ICityRepository cityRepository)
{
    public async Task ExecuteAsync(int cityId)
    {
        var city = await cityRepository.GetByIdAsync(cityId);
        if (city is null)
            throw new DomainException("Ciudad no encontrada");

        await cityRepository.DeleteAsync(city);
    }
}
