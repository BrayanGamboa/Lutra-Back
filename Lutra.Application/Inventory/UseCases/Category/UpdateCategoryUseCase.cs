using Lutra.Application.Inventory.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Inventory.UseCases.Category;

public class UpdateCategoryUseCase(ICategoryRepository categoryRepository)
{
    public async Task<CategoryResponse> ExecuteAsync(int id, CategoryRequest request)
    {
        var category = await categoryRepository.GetByIdAsync(id);
        if (category is null)
        {
            throw new DomainException("Categoría no encontrada");
        }

        category.Update(request.Name, request.Description);
        await categoryRepository.UpdateAsync(category);

        return CategoryResponse.FromDomain(category);
    }
}
