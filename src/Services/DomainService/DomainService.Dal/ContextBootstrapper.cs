using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DomainService.Dal;

/// <summary>
/// Extension for IServiceCollection, register DbContext with connection string and params
/// </summary>
public static class ContextBootstrapper
{
    /// <summary>
    /// Register Ef core Npgsql
    /// </summary>
    /// <typeparam name="TContext">DbCotnext</typeparam>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    /// <param name="connectionString">Name of connection string</param>
    /// <returns></returns>
    public static IServiceCollection RegisterEntityFramework<TContext>(this IServiceCollection services, string? connectionString)
        where TContext : DbContext
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString));
        }

        services.AddDbContext<TContext>(o => o.UseNpgsql(connectionString));

        return services;

    }
}
