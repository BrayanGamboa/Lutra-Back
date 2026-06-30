using Lutra.Application.Customers.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Customers.UseCases.CustomerDetailsInfo;

public class GetCustomerDetailsByUserUseCase(ICustomerDetailsInfoRepository customerDetailsInfoRepository)
{
    public async Task<CustomerDetailsInfoResponse> ExecuteAsync(Guid userId)
    {
        var info = await customerDetailsInfoRepository.GetByUserIdAsync(userId);
        if (info is null)
            throw new DomainException("Info de cliente no encontrada");

        return CustomerDetailsInfoResponse.FromDomain(info);
    }
}
