using Lutra.Application.Inventory.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Inventory.UseCases.ReferencesType;

public class DeleteReferencesTypeUseCase(IReferencesTypeRepository referencesTypeRepository)
{
    public async Task ExecuteAsync(int id)
    {
        var referencesType = await referencesTypeRepository.GetByIdAsync(id);
        if (referencesType is null)
        {
            throw new DomainException("Tipo de referencia no encontrado");
        }

        await referencesTypeRepository.DeleteAsync(referencesType);
    }
}
