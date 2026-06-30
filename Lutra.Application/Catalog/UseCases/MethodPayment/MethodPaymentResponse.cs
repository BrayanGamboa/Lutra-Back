namespace Lutra.Application.Catalog.UseCases.MethodPayment;

public record MethodPaymentResponse(int PaymentMethodId, string Name, DateTime? CreatedAt)
{
    public static MethodPaymentResponse FromDomain(Domain.Catalog.MethodPayment methodPayment) =>
        new(methodPayment.PaymentMethodId, methodPayment.Name, methodPayment.CreatedAt);
}
