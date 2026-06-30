using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.TaxRegime;

public class GetTaxRegimeByIdUseCase(ITaxRegimeRepository taxRegimeRepository)
{
    public async Task<TaxRegimeResponse> ExecuteAsync(int taxRegimeId)
    {
        var taxRegime = await taxRegimeRepository.GetByIdAsync(taxRegimeId);
        if (taxRegime is null)
            throw new DomainException("Régimen tributario no encontrado");

        return TaxRegimeResponse.FromDomain(taxRegime);
    }
}
