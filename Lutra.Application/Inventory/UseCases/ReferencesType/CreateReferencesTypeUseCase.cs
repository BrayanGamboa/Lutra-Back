using Lutra.Application.Inventory.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Inventory.UseCases.ReferencesType;

public class CreateReferencesTypeUseCase(IReferencesTypeRepository referencesTypeRepository)
{
    public async Task<ReferencesTypeResponse> ExecuteAsync(ReferencesTypeRequest request)
    {
        var exists = await referencesTypeRepository.ExistsAsync(request.Name);
        if (exists)
        {
            throw new DomainException("El tipo de referencia ya existe");
        }

        var referencesType = Domain.Inventory.ReferencesType.Create(request.Name, request.Description);
        await referencesTypeRepository.AddAsync(referencesType);

        return ReferencesTypeResponse.FromDomain(referencesType);
    }
}
