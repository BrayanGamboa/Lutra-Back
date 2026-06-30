namespace Lutra.Domain.Sales;
public class Sale
{
    public Guid SaleId { get; set; }
    public Guid CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public int? PaymentMethodId { get; set; }
    public DateTime? SaleDate { get; set; }
    public string Status { get; set; } = "PENDING";
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    private Sale() { }
    public static Sale Create(Guid customerId, decimal totalAmount, int? paymentMethodId) =>
        new Sale { SaleId = Guid.NewGuid(), CustomerId = customerId, TotalAmount = totalAmount, PaymentMethodId = paymentMethodId, SaleDate = DateTime.UtcNow, Status = "PENDING", CreatedAt = DateTime.UtcNow };
    public void UpdateStatus(string status) { Status = status; UpdatedAt = DateTime.UtcNow; }
    public void Update(decimal totalAmount, int? paymentMethodId) { TotalAmount = totalAmount; PaymentMethodId = paymentMethodId; UpdatedAt = DateTime.UtcNow; }
}
