using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.Country;

public class CreateCountryUseCase(ICountryRepository countryRepository)
{
    public async Task<CountryResponse> ExecuteAsync(CountryRequest request)
    {
        var exists = await countryRepository.ExistsAsync(request.Name);
        if (exists)
            throw new DomainException("El país ya existe");

        var country = Domain.Catalog.Country.Create(request.Name);
        await countryRepository.AddAsync(country);

        return CountryResponse.FromDomain(country);
    }
}
