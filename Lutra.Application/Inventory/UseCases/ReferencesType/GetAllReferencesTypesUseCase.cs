using Lutra.Application.Inventory.Ports;

namespace Lutra.Application.Inventory.UseCases.ReferencesType;

public class GetAllReferencesTypesUseCase(IReferencesTypeRepository referencesTypeRepository)
{
    public async Task<IEnumerable<ReferencesTypeResponse>> ExecuteAsync()
    {
        var referencesTypes = await referencesTypeRepository.GetAllAsync();
        return referencesTypes.Select(ReferencesTypeResponse.FromDomain);
    }
}
