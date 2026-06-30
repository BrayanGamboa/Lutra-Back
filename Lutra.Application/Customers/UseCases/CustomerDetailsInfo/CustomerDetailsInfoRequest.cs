namespace Lutra.Application.Customers.UseCases.CustomerDetailsInfo;

public record CustomerDetailsInfoRequest(
    Guid UserId,
    int? DocumentTypeId,
    string? DocumentNumber,
    string? BusinessName,
    string? BillingAddress,
    string? Phone,
    int? CityId,
    int? TaxRegimeId,
    string? CustomerName,
    string? CustomerDocument);
