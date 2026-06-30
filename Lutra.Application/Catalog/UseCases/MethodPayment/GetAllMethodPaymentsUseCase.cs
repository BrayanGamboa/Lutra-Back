using Lutra.Application.Catalog.Ports;

namespace Lutra.Application.Catalog.UseCases.MethodPayment;

public class GetAllMethodPaymentsUseCase(IMethodPaymentRepository methodPaymentRepository)
{
    public async Task<IEnumerable<MethodPaymentResponse>> ExecuteAsync()
    {
        var methodPayments = await methodPaymentRepository.GetAllAsync();
        return methodPayments.Select(MethodPaymentResponse.FromDomain);
    }
}
