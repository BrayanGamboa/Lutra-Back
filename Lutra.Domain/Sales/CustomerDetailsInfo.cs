namespace Lutra.Domain.Sales;
public class CustomerDetailsInfo
{
    public int CustomerDetailId { get; set; }
    public Guid UserId { get; set; }
    public int? DocumentTypeId { get; set; }
    public string? DocumentNumber { get; set; }
    public string? BusinessName { get; set; }
    public string? BillingAddress { get; set; }
    public string? Phone { get; set; }
    public int? CityId { get; set; }
    public int? TaxRegimeId { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerDocument { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    private CustomerDetailsInfo() { }
    public static CustomerDetailsInfo Create(Guid userId, int? documentTypeId, string? documentNumber, string? businessName, string? billingAddress, string? phone, int? cityId, int? taxRegimeId, string? customerName, string? customerDocument) =>
        new CustomerDetailsInfo { UserId = userId, DocumentTypeId = documentTypeId, DocumentNumber = documentNumber, BusinessName = businessName, BillingAddress = billingAddress, Phone = phone, CityId = cityId, TaxRegimeId = taxRegimeId, CustomerName = customerName, CustomerDocument = customerDocument, CreatedAt = DateTime.UtcNow };
    public void Update(int? documentTypeId, string? documentNumber, string? businessName, string? billingAddress, string? phone, int? cityId, int? taxRegimeId, string? customerName, string? customerDocument) {
        DocumentTypeId = documentTypeId; DocumentNumber = documentNumber; BusinessName = businessName; BillingAddress = billingAddress; Phone = phone; CityId = cityId; TaxRegimeId = taxRegimeId; CustomerName = customerName; CustomerDocument = customerDocument; UpdatedAt = DateTime.UtcNow;
    }
}
