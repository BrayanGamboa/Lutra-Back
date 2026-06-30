using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.MethodPayment;

public class UpdateMethodPaymentUseCase(IMethodPaymentRepository methodPaymentRepository)
{
    public async Task<MethodPaymentResponse> ExecuteAsync(int paymentMethodId, MethodPaymentRequest request)
    {
        var methodPayment = await methodPaymentRepository.GetByIdAsync(paymentMethodId);
        if (methodPayment is null)
            throw new DomainException("Método de pago no encontrado");

        methodPayment.Update(request.Name);
        await methodPaymentRepository.UpdateAsync(methodPayment);

        return MethodPaymentResponse.FromDomain(methodPayment);
    }
}
