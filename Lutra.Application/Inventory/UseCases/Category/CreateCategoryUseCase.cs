using Lutra.Application.Inventory.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Inventory.UseCases.Category;

public class CreateCategoryUseCase(ICategoryRepository categoryRepository)
{
    public async Task<CategoryResponse> ExecuteAsync(CategoryRequest request)
    {
        var exists = await categoryRepository.ExistsAsync(request.Name);
        if (exists)
        {
            throw new DomainException("La categoría ya existe");
        }

        var category = Domain.Inventory.Category.Create(request.Name, request.Description);
        await categoryRepository.AddAsync(category);

        return CategoryResponse.FromDomain(category);
    }
}
