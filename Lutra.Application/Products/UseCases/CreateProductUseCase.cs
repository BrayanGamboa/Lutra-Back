using Lutra.Application.Products.Ports;
using Lutra.Domain.Shared;

namespace Lutra.Application.Products.UseCases;

public class CreateProductUseCase(IProductRepository productRepository)
{
    public async Task<ProductResponse> ExecuteAsync(ProductRequest request)
    {
        var existsBySku = await productRepository.ExistsBySkuAsync(request.Sku);
        if (existsBySku)
        {
            throw new DomainException("Ya existe un producto con el SKU indicado");
        }

        var product = Domain.Inventory.Product.Create(request.Name, request.Description, request.Sku, request.Price, request.Cost, request.SupplierId, request.CategoryId);
        await productRepository.AddAsync(product);

        return ProductResponse.FromDomain(product);
    }
}
