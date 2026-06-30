using Lutra.Application.Inventory.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Inventory.UseCases.ReferencesType;

public class GetReferencesTypeByIdUseCase(IReferencesTypeRepository referencesTypeRepository)
{
    public async Task<ReferencesTypeResponse> ExecuteAsync(int id)
    {
        var referencesType = await referencesTypeRepository.GetByIdAsync(id);
        if (referencesType is null)
        {
            throw new DomainException("Tipo de referencia no encontrado");
        }

        return ReferencesTypeResponse.FromDomain(referencesType);
    }
}
