using Lutra.Application.Customers.UseCases.CustomerDetailsInfo;
using Microsoft.Extensions.DependencyInjection;

namespace Lutra.Application.Customers;

public static class CustomersApplicationExtensions
{
    public static IServiceCollection AddCustomersApplication(this IServiceCollection services)
    {
        services.AddScoped<GetCustomerDetailsByUserUseCase>();
        services.AddScoped<UpsertCustomerDetailsInfoUseCase>();

        return services;
    }
}
