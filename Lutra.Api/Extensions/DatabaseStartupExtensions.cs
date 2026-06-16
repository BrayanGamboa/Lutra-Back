using Lutra.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Api.Extensions;

public static class DatabaseStartupExtensions
{
    public static async Task ApplyDatabaseMigrationsAsync(this WebApplication app)
    {
        var autoMigrate = app.Configuration.GetValue<bool>("Database:AutoMigrate");
        if (!autoMigrate)
        {
            return;
        }

        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}
