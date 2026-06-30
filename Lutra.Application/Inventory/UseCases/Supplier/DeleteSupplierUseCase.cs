using Lutra.Application.Inventory.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Inventory.UseCases.Supplier;

public class DeleteSupplierUseCase(ISupplierRepository supplierRepository)
{
    public async Task ExecuteAsync(int id)
    {
        var supplier = await supplierRepository.GetByIdAsync(id);
        if (supplier is null)
        {
            throw new DomainException("Proveedor no encontrado");
        }

        await supplierRepository.DeleteAsync(supplier);
    }
}
