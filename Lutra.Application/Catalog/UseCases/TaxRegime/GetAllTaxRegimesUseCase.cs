using Lutra.Application.Catalog.Ports;

namespace Lutra.Application.Catalog.UseCases.TaxRegime;

public class GetAllTaxRegimesUseCase(ITaxRegimeRepository taxRegimeRepository)
{
    public async Task<IEnumerable<TaxRegimeResponse>> ExecuteAsync()
    {
        var taxRegimes = await taxRegimeRepository.GetAllAsync();
        return taxRegimes.Select(TaxRegimeResponse.FromDomain);
    }
}
