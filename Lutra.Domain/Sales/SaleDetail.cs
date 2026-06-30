namespace Lutra.Domain.Sales;
public class SaleDetail
{
    public int SaleDetailId { get; set; }
    public Guid SaleId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal? Subtotal { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    private SaleDetail() { }
    public static SaleDetail Create(Guid saleId, int productId, int quantity, decimal unitPrice) =>
        new SaleDetail { SaleId = saleId, ProductId = productId, Quantity = quantity, UnitPrice = unitPrice, Subtotal = quantity * unitPrice, CreatedAt = DateTime.UtcNow };
}
