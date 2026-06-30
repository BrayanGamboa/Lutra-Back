namespace Lutra.Application.Inventory.UseCases.Category;

public record CategoryResponse(int CategoryId, string Name, string? Description, DateTime? CreatedAt)
{
    public static CategoryResponse FromDomain(Domain.Inventory.Category category) =>
        new(category.CategoryId, category.Name, category.Description, category.CreatedAt);
}
