using Lutra.Application.Customers.Ports;

namespace Lutra.Application.Customers.UseCases.CustomerDetailsInfo;

public class UpsertCustomerDetailsInfoUseCase(ICustomerDetailsInfoRepository customerDetailsInfoRepository)
{
    public async Task<CustomerDetailsInfoResponse> ExecuteAsync(CustomerDetailsInfoRequest request)
    {
        var existing = await customerDetailsInfoRepository.GetByUserIdAsync(request.UserId);

        if (existing is not null)
        {
            existing.Update(
                request.DocumentTypeId,
                request.DocumentNumber,
                request.BusinessName,
                request.BillingAddress,
                request.Phone,
                request.CityId,
                request.TaxRegimeId,
                request.CustomerName,
                request.CustomerDocument);

            await customerDetailsInfoRepository.UpdateAsync(existing);
            return CustomerDetailsInfoResponse.FromDomain(existing);
        }

        var created = Domain.Sales.CustomerDetailsInfo.Create(
            request.UserId,
            request.DocumentTypeId,
            request.DocumentNumber,
            request.BusinessName,
            request.BillingAddress,
            request.Phone,
            request.CityId,
            request.TaxRegimeId,
            request.CustomerName,
            request.CustomerDocument);

        await customerDetailsInfoRepository.AddAsync(created);
        return CustomerDetailsInfoResponse.FromDomain(created);
    }
}
