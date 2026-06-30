using Lutra.Application.Catalog.Ports;

namespace Lutra.Application.Catalog.UseCases.Country;

public class GetAllCountriesUseCase(ICountryRepository countryRepository)
{
    public async Task<IEnumerable<CountryResponse>> ExecuteAsync()
    {
        var countries = await countryRepository.GetAllAsync();
        return countries.Select(CountryResponse.FromDomain);
    }
}
