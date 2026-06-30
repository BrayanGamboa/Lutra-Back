using Lutra.Application.Auth.Ports;
using Lutra.Application.Catalog.Ports;
using Lutra.Application.Customers.Ports;
using Lutra.Application.Inventory.Ports;
using Lutra.Application.Products.Ports;
using Lutra.Application.Sales.Ports;
using Lutra.Infrastructure.Persistence;
using Lutra.Infrastructure.Persistence.Auth;
using Lutra.Infrastructure.Persistence.Catalog;
using Lutra.Infrastructure.Persistence.Customers;
using Lutra.Infrastructure.Persistence.Inventory;
using Lutra.Infrastructure.Persistence.Products;
using Lutra.Infrastructure.Persistence.Sales;
using Lutra.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lutra.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = ConnectionStringResolver.ResolveFromConfiguration(configuration);

        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<IUserRepository, EfUserRepository>();
        services.AddScoped<IRoleRepository, EfRoleRepository>();
        services.AddScoped<ITokenManager, JwtTokenManager>();
        services.AddSingleton<IPasswordHasher, BcryptPasswordHasher>();
        services.AddScoped<IRoleUsersDetailRepository, EfRoleUsersDetailRepository>();

        services.AddScoped<ICountryRepository, EfCountryRepository>();
        services.AddScoped<IDepartmentRepository, EfDepartmentRepository>();
        services.AddScoped<ICityRepository, EfCityRepository>();
        services.AddScoped<IDocumentTypeRepository, EfDocumentTypeRepository>();
        services.AddScoped<IMethodPaymentRepository, EfMethodPaymentRepository>();
        services.AddScoped<ITaxRegimeRepository, EfTaxRegimeRepository>();

        services.AddScoped<ICategoryRepository, EfCategoryRepository>();
        services.AddScoped<ISupplierRepository, EfSupplierRepository>();
        services.AddScoped<IReferencesTypeRepository, EfReferencesTypeRepository>();
        services.AddScoped<IInventoryMovementRepository, EfInventoryMovementRepository>();

        services.AddScoped<IProductRepository, EfProductRepository>();

        services.AddScoped<ISaleRepository, EfSaleRepository>();
        services.AddScoped<ISaleDetailRepository, EfSaleDetailRepository>();

        services.AddScoped<ICustomerDetailsInfoRepository, EfCustomerDetailsInfoRepository>();

        return services;
    }
}
