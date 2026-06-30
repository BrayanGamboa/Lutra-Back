using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.TaxRegime;

public class CreateTaxRegimeUseCase(ITaxRegimeRepository taxRegimeRepository)
{
    public async Task<TaxRegimeResponse> ExecuteAsync(TaxRegimeRequest request)
    {
        var exists = await taxRegimeRepository.ExistsAsync(request.Name);
        if (exists)
            throw new DomainException("El régimen tributario ya existe");

        var taxRegime = Domain.Catalog.TaxRegime.Create(request.Name, request.Description);
        await taxRegimeRepository.AddAsync(taxRegime);

        return TaxRegimeResponse.FromDomain(taxRegime);
    }
}
