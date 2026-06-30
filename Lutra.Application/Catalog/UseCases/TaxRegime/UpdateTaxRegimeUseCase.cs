using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.TaxRegime;

public class UpdateTaxRegimeUseCase(ITaxRegimeRepository taxRegimeRepository)
{
    public async Task<TaxRegimeResponse> ExecuteAsync(int taxRegimeId, TaxRegimeRequest request)
    {
        var taxRegime = await taxRegimeRepository.GetByIdAsync(taxRegimeId);
        if (taxRegime is null)
            throw new DomainException("Régimen tributario no encontrado");

        taxRegime.Update(request.Name, request.Description);
        await taxRegimeRepository.UpdateAsync(taxRegime);

        return TaxRegimeResponse.FromDomain(taxRegime);
    }
}
