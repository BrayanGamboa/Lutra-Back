using Lutra.Application.Sales.UseCases.Sale;
using Lutra.Application.Sales.UseCases.SaleDetail;
using Microsoft.Extensions.DependencyInjection;

namespace Lutra.Application.Sales;

public static class SalesApplicationExtensions
{
    public static IServiceCollection AddSalesApplication(this IServiceCollection services)
    {
        services.AddScoped<GetAllSalesUseCase>();
        services.AddScoped<GetSaleByIdUseCase>();
        services.AddScoped<GetSalesByCustomerUseCase>();
        services.AddScoped<CreateSaleUseCase>();
        services.AddScoped<UpdateSaleStatusUseCase>();

        services.AddScoped<GetSaleDetailsBySaleUseCase>();
        services.AddScoped<GetSaleDetailByIdUseCase>();
        services.AddScoped<CreateSaleDetailUseCase>();
        services.AddScoped<DeleteSaleDetailUseCase>();

        return services;
    }
}
