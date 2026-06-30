using Lutra.Application.Inventory.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Inventory.UseCases.Supplier;

public class CreateSupplierUseCase(ISupplierRepository supplierRepository)
{
    public async Task<SupplierResponse> ExecuteAsync(SupplierRequest request)
    {
        var exists = await supplierRepository.ExistsAsync(request.Name);
        if (exists)
        {
            throw new DomainException("El proveedor ya existe");
        }

        var supplier = Domain.Inventory.Supplier.Create(request.Name, request.ContactName, request.Email, request.Phone, request.Address);
        await supplierRepository.AddAsync(supplier);

        return SupplierResponse.FromDomain(supplier);
    }
}
