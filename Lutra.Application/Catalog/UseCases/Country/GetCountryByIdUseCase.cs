using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.Country;

public class GetCountryByIdUseCase(ICountryRepository countryRepository)
{
    public async Task<CountryResponse> ExecuteAsync(int countryId)
    {
        var country = await countryRepository.GetByIdAsync(countryId);
        if (country is null)
            throw new DomainException("País no encontrado");

        return CountryResponse.FromDomain(country);
    }
}
