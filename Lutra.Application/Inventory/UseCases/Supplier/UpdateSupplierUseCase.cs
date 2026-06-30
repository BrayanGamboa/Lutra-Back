using Lutra.Application.Inventory.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Inventory.UseCases.Supplier;

public class UpdateSupplierUseCase(ISupplierRepository supplierRepository)
{
    public async Task<SupplierResponse> ExecuteAsync(int id, SupplierRequest request)
    {
        var supplier = await supplierRepository.GetByIdAsync(id);
        if (supplier is null)
        {
            throw new DomainException("Proveedor no encontrado");
        }

        supplier.Update(request.Name, request.ContactName, request.Email, request.Phone, request.Address);
        await supplierRepository.UpdateAsync(supplier);

        return SupplierResponse.FromDomain(supplier);
    }
}
