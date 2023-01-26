using DomainService.Core.Domain.Entities;
using DomainService.Dal;
using DomainService.Dal.Abstractions;
using DomainService.Dal.Repositories;

namespace DomainService.WebApi.Extensions;

/// <summary>
/// Extension for repositories registration
/// </summary>
public static class RepositoriesExtensions
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<ICommandRepository<User, Guid>, DefaultCommandRepository<User, AppDbContext, Guid>>()
            .AddScoped<IQueryRepository<User, Guid>, DefaultQueryRepository<User, AppDbContext, Guid>>()
            .AddScoped<IQueryRepository<Country, Guid>, DefaultQueryRepository<Country, AppDbContext, Guid>>()
            .AddScoped<IQueryRepository<Province, Guid>, DefaultQueryRepository<Province, AppDbContext, Guid>>();

        services.AddScoped<IUnitOfWork<AppDbContext>, UnitOfWork<AppDbContext>>();

        return services;
    }
}
