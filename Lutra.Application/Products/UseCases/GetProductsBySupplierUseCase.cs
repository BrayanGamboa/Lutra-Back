using Lutra.Application.Products.Ports;

namespace Lutra.Application.Products.UseCases;

public class GetProductsBySupplierUseCase(IProductRepository productRepository)
{
    public async Task<IEnumerable<ProductResponse>> ExecuteAsync(int supplierId)
    {
        var products = await productRepository.GetBySupplierAsync(supplierId);
        return products.Select(ProductResponse.FromDomain);
    }
}
