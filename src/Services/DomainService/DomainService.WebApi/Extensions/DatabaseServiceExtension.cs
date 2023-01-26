using Microsoft.EntityFrameworkCore;

namespace DomainService.WebApi.Extensions;

/// <summary>
/// Extension for DbContexts
/// </summary>
/// <typeparam name="TContext"></typeparam>
internal static class DatabaseServiceExtension<TContext>
    where TContext : DbContext
{
    /// <summary>
    /// Apply migration when app starts
    /// </summary>
    /// <param name="provider"><see cref="IServiceProvider"/></param>
    public static void PrepareDbAndSeed(IServiceProvider provider)
    {
        using var scope = provider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<TContext>();
        db.Database.Migrate();
    }
}
