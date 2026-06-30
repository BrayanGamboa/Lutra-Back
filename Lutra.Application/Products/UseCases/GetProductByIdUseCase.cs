using Lutra.Application.Products.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Products.UseCases;

public class GetProductByIdUseCase(IProductRepository productRepository)
{
    public async Task<ProductResponse> ExecuteAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id);
        if (product is null)
        {
            throw new DomainException("Producto no encontrado");
        }

        return ProductResponse.FromDomain(product);
    }
}
