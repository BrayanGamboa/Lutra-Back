using Lutra.Application.Products.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Products.UseCases;

public class DeleteProductUseCase(IProductRepository productRepository)
{
    public async Task ExecuteAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id);
        if (product is null)
        {
            throw new DomainException("Producto no encontrado");
        }

        await productRepository.DeleteAsync(product);
    }
}
