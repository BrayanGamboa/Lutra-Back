using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.MethodPayment;

public class DeleteMethodPaymentUseCase(IMethodPaymentRepository methodPaymentRepository)
{
    public async Task ExecuteAsync(int paymentMethodId)
    {
        var methodPayment = await methodPaymentRepository.GetByIdAsync(paymentMethodId);
        if (methodPayment is null)
            throw new DomainException("Método de pago no encontrado");

        await methodPaymentRepository.DeleteAsync(methodPayment);
    }
}
