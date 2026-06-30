namespace Lutra.Domain.Catalog;
public class MethodPayment
{
    public int PaymentMethodId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    private MethodPayment() { }
    public static MethodPayment Create(string name) => new MethodPayment { Name = name, CreatedAt = DateTime.UtcNow };
    public void Update(string name) { Name = name; UpdatedAt = DateTime.UtcNow; }
}
