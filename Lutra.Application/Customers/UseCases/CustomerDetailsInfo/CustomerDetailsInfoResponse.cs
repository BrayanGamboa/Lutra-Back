namespace Lutra.Application.Customers.UseCases.CustomerDetailsInfo;

public record CustomerDetailsInfoResponse(
    int CustomerDetailId,
    Guid UserId,
    int? DocumentTypeId,
    string? DocumentNumber,
    string? BusinessName,
    string? BillingAddress,
    string? Phone,
    int? CityId,
    int? TaxRegimeId,
    string? CustomerName,
    string? CustomerDocument,
    DateTime? CreatedAt,
    DateTime? UpdatedAt)
{
    public static CustomerDetailsInfoResponse FromDomain(Domain.Sales.CustomerDetailsInfo c) =>
        new(c.CustomerDetailId, c.UserId, c.DocumentTypeId, c.DocumentNumber, c.BusinessName,
            c.BillingAddress, c.Phone, c.CityId, c.TaxRegimeId, c.CustomerName, c.CustomerDocument,
            c.CreatedAt, c.UpdatedAt);
}
