using Lutra.Application.Products.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Products.UseCases;

public class UpdateProductUseCase(IProductRepository productRepository)
{
    public async Task<ProductResponse> ExecuteAsync(int id, ProductRequest request)
    {
        var product = await productRepository.GetByIdAsync(id);
        if (product is null)
        {
            throw new DomainException("Producto no encontrado");
        }

        product.Update(request.Name, request.Description, request.Price, request.Cost, request.SupplierId, request.CategoryId, request.IsActive);
        await productRepository.UpdateAsync(product);

        return ProductResponse.FromDomain(product);
    }
}
