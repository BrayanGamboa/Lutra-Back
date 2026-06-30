using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.MethodPayment;

public class GetMethodPaymentByIdUseCase(IMethodPaymentRepository methodPaymentRepository)
{
    public async Task<MethodPaymentResponse> ExecuteAsync(int paymentMethodId)
    {
        var methodPayment = await methodPaymentRepository.GetByIdAsync(paymentMethodId);
        if (methodPayment is null)
            throw new DomainException("Método de pago no encontrado");

        return MethodPaymentResponse.FromDomain(methodPayment);
    }
}
