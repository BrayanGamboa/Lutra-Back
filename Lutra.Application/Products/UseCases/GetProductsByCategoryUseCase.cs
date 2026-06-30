using Lutra.Application.Products.Ports;

namespace Lutra.Application.Products.UseCases;

public class GetProductsByCategoryUseCase(IProductRepository productRepository)
{
    public async Task<IEnumerable<ProductResponse>> ExecuteAsync(int categoryId)
    {
        var products = await productRepository.GetByCategoryAsync(categoryId);
        return products.Select(ProductResponse.FromDomain);
    }
}
