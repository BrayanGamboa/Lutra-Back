using Lutra.Application.Catalog.UseCases.City;
using Lutra.Application.Catalog.UseCases.Country;
using Lutra.Application.Catalog.UseCases.Department;
using Lutra.Application.Catalog.UseCases.DocumentType;
using Lutra.Application.Catalog.UseCases.MethodPayment;
using Lutra.Application.Catalog.UseCases.TaxRegime;
using Microsoft.Extensions.DependencyInjection;

namespace Lutra.Application.Catalog;

public static class CatalogApplicationExtensions
{
    public static IServiceCollection AddCatalogUseCases(this IServiceCollection services)
    {
        // Country
        services.AddScoped<GetAllCountriesUseCase>();
        services.AddScoped<GetCountryByIdUseCase>();
        services.AddScoped<CreateCountryUseCase>();
        services.AddScoped<UpdateCountryUseCase>();
        services.AddScoped<DeleteCountryUseCase>();

        // Department
        services.AddScoped<GetAllDepartmentsUseCase>();
        services.AddScoped<GetDepartmentByIdUseCase>();
        services.AddScoped<GetDepartmentsByCountryUseCase>();
        services.AddScoped<CreateDepartmentUseCase>();
        services.AddScoped<UpdateDepartmentUseCase>();
        services.AddScoped<DeleteDepartmentUseCase>();

        // City
        services.AddScoped<GetAllCitiesUseCase>();
        services.AddScoped<GetCityByIdUseCase>();
        services.AddScoped<GetCitiesByDepartmentUseCase>();
        services.AddScoped<CreateCityUseCase>();
        services.AddScoped<UpdateCityUseCase>();
        services.AddScoped<DeleteCityUseCase>();

        // DocumentType
        services.AddScoped<GetAllDocumentTypesUseCase>();
        services.AddScoped<GetDocumentTypeByIdUseCase>();
        services.AddScoped<CreateDocumentTypeUseCase>();
        services.AddScoped<UpdateDocumentTypeUseCase>();
        services.AddScoped<DeleteDocumentTypeUseCase>();

        // MethodPayment
        services.AddScoped<GetAllMethodPaymentsUseCase>();
        services.AddScoped<GetMethodPaymentByIdUseCase>();
        services.AddScoped<CreateMethodPaymentUseCase>();
        services.AddScoped<UpdateMethodPaymentUseCase>();
        services.AddScoped<DeleteMethodPaymentUseCase>();

        // TaxRegime
        services.AddScoped<GetAllTaxRegimesUseCase>();
        services.AddScoped<GetTaxRegimeByIdUseCase>();
        services.AddScoped<CreateTaxRegimeUseCase>();
        services.AddScoped<UpdateTaxRegimeUseCase>();
        services.AddScoped<DeleteTaxRegimeUseCase>();

        return services;
    }
}
