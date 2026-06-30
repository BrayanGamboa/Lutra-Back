using Lutra.Application.Sales.Ports;
using Lutra.Application.Shared;
using Lutra.Domain.Shared;

namespace Lutra.Application.Sales.UseCases.Sale;

public class GetAllSalesUseCase(ISaleRepository saleRepository)
{
    public async Task<IEnumerable<SaleResponse>> ExecuteAsync(
        CurrentUserContext user, SaleFilters requested)
    {
        var scope = ApplyRoleScope(user, requested);
        var sales = await saleRepository.GetAllAsync(scope);
        return sales.Select(SaleResponse.FromDomain);
    }

    private static SaleFilters ApplyRoleScope(CurrentUserContext user, SaleFilters requested)
    {
        if (user.HasRole("Administrador") || user.HasRole("Contador"))
            return requested;

        if (user.HasRole("Supervisor"))
            // TODO: Sale entity has no team relationship; returning all sales for Supervisor role
            return requested;

        if (user.HasRole("Vendedor"))
            // TODO: Sale entity has no VendedorId field; returning all sales for Vendedor role
            return requested;

        if (user.HasRole("Cliente"))
            return requested with { ClienteId = user.UserId };

        if (user.HasRole("Inventario"))
            throw new ForbiddenException("El rol Inventario no tiene acceso a facturas.");

        return requested;
    }
}
