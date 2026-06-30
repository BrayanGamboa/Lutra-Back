using Lutra.Application.Products.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Lutra.Application.Products;

public static class ProductApplicationExtensions
{
    public static IServiceCollection AddProductApplication(this IServiceCollection services)
    {
        services.AddScoped<GetAllProductsUseCase>();
        services.AddScoped<GetProductByIdUseCase>();
        services.AddScoped<GetProductsByCategoryUseCase>();
        services.AddScoped<GetProductsBySupplierUseCase>();
        services.AddScoped<CreateProductUseCase>();
        services.AddScoped<UpdateProductUseCase>();
        services.AddScoped<DeleteProductUseCase>();

        return services;
    }
}
