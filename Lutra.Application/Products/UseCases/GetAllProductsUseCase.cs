using Lutra.Application.Products.Ports;

namespace Lutra.Application.Products.UseCases;

public class GetAllProductsUseCase(IProductRepository productRepository)
{
    public async Task<IEnumerable<ProductResponse>> ExecuteAsync()
    {
        var products = await productRepository.GetAllAsync();
        return products.Select(ProductResponse.FromDomain);
    }
}
