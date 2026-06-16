using Lutra.Application.Auth.Ports;
using Lutra.Infrastructure.Persistence;
using Lutra.Infrastructure.Persistence.Auth;
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
        services.AddScoped<ITokenManager, JwtTokenManager>();
        services.AddSingleton<IPasswordHasher, BcryptPasswordHasher>();

        return services;
    }
}
