using Lutra.Application.Inventory.Ports;

namespace Lutra.Application.Inventory.UseCases.Category;

public class GetAllCategoriesUseCase(ICategoryRepository categoryRepository)
{
    public async Task<IEnumerable<CategoryResponse>> ExecuteAsync()
    {
        var categories = await categoryRepository.GetAllAsync();
        return categories.Select(CategoryResponse.FromDomain);
    }
}
