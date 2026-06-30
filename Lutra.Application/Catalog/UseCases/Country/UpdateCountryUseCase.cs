using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.Country;

public class UpdateCountryUseCase(ICountryRepository countryRepository)
{
    public async Task<CountryResponse> ExecuteAsync(int countryId, CountryRequest request)
    {
        var country = await countryRepository.GetByIdAsync(countryId);
        if (country is null)
            throw new DomainException("País no encontrado");

        country.Update(request.Name);
        await countryRepository.UpdateAsync(country);

        return CountryResponse.FromDomain(country);
    }
}
