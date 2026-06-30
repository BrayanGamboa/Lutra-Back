using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.Country;

public class DeleteCountryUseCase(ICountryRepository countryRepository)
{
    public async Task ExecuteAsync(int countryId)
    {
        var country = await countryRepository.GetByIdAsync(countryId);
        if (country is null)
            throw new DomainException("País no encontrado");

        await countryRepository.DeleteAsync(country);
    }
}
