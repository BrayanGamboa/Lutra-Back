using Lutra.Application.Inventory.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Inventory.UseCases.Category;

public class DeleteCategoryUseCase(ICategoryRepository categoryRepository)
{
    public async Task ExecuteAsync(int id)
    {
        var category = await categoryRepository.GetByIdAsync(id);
        if (category is null)
        {
            throw new DomainException("Categoría no encontrada");
        }

        await categoryRepository.DeleteAsync(category);
    }
}
