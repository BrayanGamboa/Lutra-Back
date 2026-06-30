using Lutra.Application.Inventory.Ports;

namespace Lutra.Application.Inventory.UseCases.Supplier;

public class GetAllSuppliersUseCase(ISupplierRepository supplierRepository)
{
    public async Task<IEnumerable<SupplierResponse>> ExecuteAsync()
    {
        var suppliers = await supplierRepository.GetAllAsync();
        return suppliers.Select(SupplierResponse.FromDomain);
    }
}
