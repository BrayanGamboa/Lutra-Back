using Lutra.Application.Inventory.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Inventory.UseCases.ReferencesType;

public class UpdateReferencesTypeUseCase(IReferencesTypeRepository referencesTypeRepository)
{
    public async Task<ReferencesTypeResponse> ExecuteAsync(int id, ReferencesTypeRequest request)
    {
        var referencesType = await referencesTypeRepository.GetByIdAsync(id);
        if (referencesType is null)
        {
            throw new DomainException("Tipo de referencia no encontrado");
        }

        referencesType.Update(request.Name, request.Description);
        await referencesTypeRepository.UpdateAsync(referencesType);

        return ReferencesTypeResponse.FromDomain(referencesType);
    }
}
