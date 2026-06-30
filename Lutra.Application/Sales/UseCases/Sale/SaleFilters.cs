namespace Lutra.Application.Sales.UseCases.Sale;

public record SaleFilters(
    Guid? ClienteId = null,
    Guid? VendedorId = null,
    DateTime? FechaDesde = null,
    DateTime? FechaHasta = null);
