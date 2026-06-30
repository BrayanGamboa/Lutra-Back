namespace Lutra.Domain.Catalog;
public class DocumentType
{
    public int DocumentTypeId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    private DocumentType() { }
    public static DocumentType Create(string name) => new DocumentType { Name = name, CreatedAt = DateTime.UtcNow };
    public void Update(string name) { Name = name; UpdatedAt = DateTime.UtcNow; }
}
