using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.TaxRegime;

public class DeleteTaxRegimeUseCase(ITaxRegimeRepository taxRegimeRepository)
{
    public async Task ExecuteAsync(int taxRegimeId)
    {
        var taxRegime = await taxRegimeRepository.GetByIdAsync(taxRegimeId);
        if (taxRegime is null)
            throw new DomainException("Régimen tributario no encontrado");

        await taxRegimeRepository.DeleteAsync(taxRegime);
    }
}
