using Lutra.Application.Inventory.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Inventory.UseCases.Supplier;

public class GetSupplierByIdUseCase(ISupplierRepository supplierRepository)
{
    public async Task<SupplierResponse> ExecuteAsync(int id)
    {
        var supplier = await supplierRepository.GetByIdAsync(id);
        if (supplier is null)
        {
            throw new DomainException("Proveedor no encontrado");
        }

        return SupplierResponse.FromDomain(supplier);
    }
}
