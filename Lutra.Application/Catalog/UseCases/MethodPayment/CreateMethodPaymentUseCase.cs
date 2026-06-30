using Lutra.Application.Catalog.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Catalog.UseCases.MethodPayment;

public class CreateMethodPaymentUseCase(IMethodPaymentRepository methodPaymentRepository)
{
    public async Task<MethodPaymentResponse> ExecuteAsync(MethodPaymentRequest request)
    {
        var exists = await methodPaymentRepository.ExistsAsync(request.Name);
        if (exists)
            throw new DomainException("El método de pago ya existe");

        var methodPayment = Domain.Catalog.MethodPayment.Create(request.Name);
        await methodPaymentRepository.AddAsync(methodPayment);

        return MethodPaymentResponse.FromDomain(methodPayment);
    }
}
