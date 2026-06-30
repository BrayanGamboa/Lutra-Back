using Lutra.Application.Inventory.UseCases.Category;
using Lutra.Application.Inventory.UseCases.InventoryMovement;
using Lutra.Application.Inventory.UseCases.ReferencesType;
using Lutra.Application.Inventory.UseCases.Supplier;
using Microsoft.Extensions.DependencyInjection;

namespace Lutra.Application.Inventory;

public static class InventoryApplicationExtensions
{
    public static IServiceCollection AddInventoryApplication(this IServiceCollection services)
    {
        // Category
        services.AddScoped<GetAllCategoriesUseCase>();
        services.AddScoped<GetCategoryByIdUseCase>();
        services.AddScoped<CreateCategoryUseCase>();
        services.AddScoped<UpdateCategoryUseCase>();
        services.AddScoped<DeleteCategoryUseCase>();

        // Supplier
        services.AddScoped<GetAllSuppliersUseCase>();
        services.AddScoped<GetSupplierByIdUseCase>();
        services.AddScoped<CreateSupplierUseCase>();
        services.AddScoped<UpdateSupplierUseCase>();
        services.AddScoped<DeleteSupplierUseCase>();

        // ReferencesType
        services.AddScoped<GetAllReferencesTypesUseCase>();
        services.AddScoped<GetReferencesTypeByIdUseCase>();
        services.AddScoped<CreateReferencesTypeUseCase>();
        services.AddScoped<UpdateReferencesTypeUseCase>();
        services.AddScoped<DeleteReferencesTypeUseCase>();

        // InventoryMovement
        services.AddScoped<GetAllInventoryMovementsUseCase>();
        services.AddScoped<GetInventoryMovementByIdUseCase>();
        services.AddScoped<GetInventoryMovementsByProductUseCase>();
        services.AddScoped<CreateInventoryMovementUseCase>();

        return services;
    }
}
